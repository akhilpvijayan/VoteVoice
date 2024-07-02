using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using VoteService.Data;
using VoteService.Models;

namespace VoteService.Business.Services.Services
{
    public class VoteService : IVoteService
    {
        #region properties
        private readonly ILogger<VoteService> _logger;
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;

        #endregion

        #region constructor
        public VoteService(ILogger<VoteService> logger, DataContext context, IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            this._logger = logger;
            this._context = context;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        #endregion

        #region public functions
        public async Task<long> AddVote(Vote voteDetails)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    if (await ValidateUserIdAsync(voteDetails.UserId) && await ValidatePollOptionIdAsync(voteDetails.PollOptionId) && await ValidatePollIdAsync(voteDetails.PollId))
                    {
                        var existingVote = await _context.Votes.FirstOrDefaultAsync(x => x.PollId == voteDetails.PollId && x.UserId == voteDetails.UserId);
                        var host = _configuration["GatewayService:Host"];
                        var port = _configuration["GatewayService:Port"];

                        var baseAddress = $"https://{host}:{port}/";
                        var client = _httpClientFactory.CreateClient();
                        client.BaseAddress = new Uri(baseAddress);

                        //If already a vote exists for user for same poll, then remove it and update count in pollOption table, else add new vote and update count in pollOption table
                        if (existingVote != null)
                        {

                            var removeResponse = await client.GetAsync($"/poll/polloption/{existingVote.PollOptionId}/{false}");
                            if (removeResponse.IsSuccessStatusCode)
                            {
                                _context.Votes.Remove(existingVote);
                            }
                        }
                        Vote vote = new Vote();
                        vote.PollOptionId = voteDetails.PollOptionId;
                        vote.UserId = voteDetails.UserId;
                        vote.CreatedDate = DateTime.Now;

                        var addResponse = await client.GetAsync($"/poll/polloption/{voteDetails.PollOptionId}/{true}");
                        if (addResponse.IsSuccessStatusCode)
                        {
                            _context.Votes.Add(vote);

                            _context.SaveChangesAsync();
                        }
                        await transaction.CommitAsync();
                        return vote.VoteId;
                    }
                    else
                    {
                        throw new Exception("Invalid, User or Poll or Poll Option");
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

        private async Task<bool> ValidatePollOptionIdAsync(long pollOptionId)
        {
            var host = _configuration["GatewayService:Host"];
            var port = _configuration["GatewayService:Port"];

            var baseAddress = $"https://{host}:{port}/";
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(baseAddress);

            var response = await client.GetAsync($"/poll/polloption/{pollOptionId}");

            return response.IsSuccessStatusCode;
        }

        private async Task<bool> ValidateUserIdAsync(long userId)
        {
            var host = _configuration["GatewayService:Host"];
            var port = _configuration["GatewayService:Port"];

            var baseAddress = $"https://{host}:{port}/";
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(baseAddress);

            var response = await client.GetAsync($"/user/{userId}");

            return response.IsSuccessStatusCode;
        }

        private async Task<bool> ValidatePollIdAsync(long pollId)
        {
            var host = _configuration["GatewayService:Host"];
            var port = _configuration["GatewayService:Port"];

            var baseAddress = $"https://{host}:{port}/";
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(baseAddress);

            var response = await client.GetAsync($"/poll/{pollId}");

            return response.IsSuccessStatusCode;
        }
        #endregion
    }
}
