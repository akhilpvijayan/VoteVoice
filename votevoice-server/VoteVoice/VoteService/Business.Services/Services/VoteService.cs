using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Text.Json;
using VoteService.Data;
using VoteService.Models;
using VoteService.RabbitMQ.ProducerModel;
using VoteService.RabbitMQ;
using VoteService.Business.Services.Dto;

namespace VoteService.Business.Services.Services
{
    public class VoteService : IVoteService
    {
        #region properties
        private readonly ILogger<VoteService> _logger;
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly RabbitMQPublisher _rabbitMQPublisher;

        #endregion

        #region constructor
        public VoteService(ILogger<VoteService> logger, DataContext context, IConfiguration configuration, IHttpClientFactory httpClientFactory, RabbitMQPublisher rabbitMQPublisher)
        {
            this._logger = logger;
            this._context = context;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            _rabbitMQPublisher = rabbitMQPublisher;
        }

        #endregion

        #region public functions
        public async Task<long> AddVote(Vote voteDetails, string token)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    if (await ValidateUserIdAsync(voteDetails.UserId, token) &&
                        await ValidatePollOptionIdAsync(voteDetails.PollOptionId, token) &&
                        await ValidatePollIdAsync(voteDetails.PollId, token))
                    {
                        var existingVote = await _context.Votes.FirstOrDefaultAsync(x => x.PollId == voteDetails.PollId && x.UserId == voteDetails.UserId);
                        
                        if(existingVote?.PollOptionId == voteDetails.PollOptionId && existingVote?.UserId == voteDetails.UserId)
                        {
                            return 0;
                        }

                        var host = _configuration["GatewayService:Host"];
                        var port = _configuration["GatewayService:Port"];
                        var baseAddress = $"https://{host}:{port}/";
                        var client = _httpClientFactory.CreateClient();
                        client.BaseAddress = new Uri(baseAddress);

                        if (token.StartsWith("bearer ", StringComparison.OrdinalIgnoreCase))
                        {
                            token = token.Substring("bearer ".Length).Trim();
                        }

                        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                        // If a vote already exists for the user for the same poll, remove it and update count in the pollOption table
                        if (existingVote != null)
                        {
                            var requestUriToUpdate = $"/poll/polloption/{existingVote.PollOptionId}/{false}";
                            var contentToRemove = new StringContent("");
                            var removeResponse = await client.PutAsync(requestUriToUpdate, contentToRemove);
                            if (removeResponse.IsSuccessStatusCode)
                            {
                                _context.Votes.Remove(existingVote);
                                await _context.SaveChangesAsync();
                            }
                        }

                        Vote vote = new Vote
                        {
                            PollOptionId = voteDetails.PollOptionId,
                            UserId = voteDetails.UserId,
                            PollId = voteDetails.PollId,
                            CreatedDate = DateTime.Now
                        };

                        var requestUri = $"/poll/polloption/{voteDetails.PollOptionId}/{true}";
                        var content = new StringContent(""); // Replace with actual content if needed
                        var addResponse = await client.PutAsync(requestUri, content);
                        if (addResponse.IsSuccessStatusCode)
                        {
                            _context.Votes.Add(vote);
                            await _context.SaveChangesAsync();
                        }

                        await transaction.CommitAsync();

                        var pollDetails = await GetPollDetailsAsync(client, voteDetails.PollId);
                        if (pollDetails?.UserId != null)
                        {
                            var userDetails = await GetUserDetailsAsync(client, voteDetails.UserId);
                            var message = $"<b>{userDetails.FirstName} {userDetails.LastName}</b> added a new vote";
                            var notificationEvent = new NotificationEvent { TargetUser = pollDetails.UserId, Message = message };
                            _rabbitMQPublisher.Publish(notificationEvent);
                        }

                        return vote.VoteId;
                    }
                    else
                    {
                        throw new Exception("Invalid User, Poll, or Poll Option");
                    }
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw ex;
                }
            }
        }


        public async Task<long> GetVotesCount(long pollOptionId)
        {
            return await _context.Votes.CountAsync(x => x.PollOptionId == pollOptionId);
        }

        public async Task<bool> DeleteVotesByPollIds(List<long> pollIds)
        {
            var votes = _context.Votes.Where(v => pollIds.Contains(v.PollId)).ToList();

            if (votes.Any())
            {
                _context.Votes.RemoveRange(votes);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteVoteByPollOptionId(long pollOptionId)
        {
            var votes = _context.Votes.Where(v => pollOptionId == pollOptionId).ToList();

            if (votes.Any())
            {
                _context.Votes.RemoveRange(votes);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        #endregion
        #region private methods
        private async Task<bool> ValidatePollOptionIdAsync(long pollOptionId, string token)
        {
            var host = _configuration["GatewayService:Host"];
            var port = _configuration["GatewayService:Port"];

            var baseAddress = $"https://{host}:{port}/";
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(baseAddress);

            if (token.StartsWith("bearer ", StringComparison.OrdinalIgnoreCase))
            {
                token = token.Substring("bearer ".Length).Trim();
            }

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync($"/poll/polloption/{pollOptionId}");

            return response.IsSuccessStatusCode;
        }

        private async Task<bool> ValidateUserIdAsync(long userId, string token)
        {
            var host = _configuration["GatewayService:Host"];
            var port = _configuration["GatewayService:Port"];

            var baseAddress = $"https://{host}:{port}/";
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(baseAddress);

            if (token.StartsWith("bearer ", StringComparison.OrdinalIgnoreCase))
            {
                token = token.Substring("bearer ".Length).Trim();
            }

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync($"/user/{userId}");

            return response.IsSuccessStatusCode;
        }

        private async Task<bool> ValidatePollIdAsync(long pollId, string token)
        {
            var host = _configuration["GatewayService:Host"];
            var port = _configuration["GatewayService:Port"];

            var baseAddress = $"https://{host}:{port}/";
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(baseAddress);

            if (token.StartsWith("bearer ", StringComparison.OrdinalIgnoreCase))
            {
                token = token.Substring("bearer ".Length).Trim();
            }

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync($"/poll/{pollId}");

            return response.IsSuccessStatusCode;
        }

        private async Task<PollDetailsDto> GetPollDetailsAsync(HttpClient client, long pollId)
        {
            var response = await client.GetAsync($"/poll/{pollId}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<PollDetailsDto>();
        }

        private async Task<UserDetailDto> GetUserDetailsAsync(HttpClient client, long userId)
        {
            var response = await client.GetAsync($"/user/{userId}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<UserDetailDto>();
        }
        #endregion
    }
}
