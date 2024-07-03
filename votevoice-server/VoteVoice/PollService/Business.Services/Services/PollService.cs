using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PollService.Business.Entities;
using PollService.Business.Services.Dto;
using PollService.Data;
using PollService.Models;
using System.Net.Http;
using System.Net.Http.Formatting;

namespace PollService.Business.Services.Services
{
    public class PollService : IPollService
    {
        #region properties
        private readonly ILogger<PollService> _logger;
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        #endregion

        #region constructor
        public PollService(ILogger<PollService> logger, DataContext context, IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            this._logger = logger;
            this._context = context;
            this._configuration = configuration;
            this._httpClientFactory = httpClientFactory;
        }

        #endregion

        #region public functions
        public async Task<IEnumerable<PollDetailsDto>> GetAllPolls(int skip, int take)
        {
            // Fetch polls with pagination
            var polls = await _context.Polls
                                      .Skip(skip)
                                      .Take(take)
                                      .ToListAsync();

            // Fetch corresponding poll options for the fetched polls
            var pollIds = polls.Select(p => p.PollId).ToList();
            var pollOptions = await _context.PollOptions
                                            .Where(po => pollIds.Contains(po.PollId))
                                            .ToListAsync();

            var aggregatedPollDetails = new List<PollDetailsDto>();

            foreach (var poll in polls)
            {
                var host = _configuration["GateService:Host"];
                var port = _configuration["GatewayService:Port"];

                var baseAddress = $"https://{host}:{port}/";
                var client = _httpClientFactory.CreateClient();
                client.BaseAddress = new Uri(baseAddress);

                var userResponse = await client.GetAsync($"/user/{poll.UserId}");
                userResponse.EnsureSuccessStatusCode();
                var userDetails = await userResponse.Content.ReadAsAsync<UserDetailDto>();


                var optionsForPoll = pollOptions.Where(po => po.PollId == poll.PollId).ToList();

                aggregatedPollDetails.Add(new PollDetailsDto
                {
                    PollId = poll.PollId,
                    UserId = poll.UserId,
                    Title = poll.Title,
                    Description = poll.Description,
                    FirstName = userDetails.FirstName,
                    LastName = userDetails.LastName,
                    ExpiryDate = poll.ExpiryDate,
                    PollOptions = optionsForPoll.Select(po => new PollOptions
                    {
                        PollOptionId = po.PollOptionId,
                        PollId = po.PollId,
                        OptionText = po.OptionText,
                        PollImage = po.PollImage,
                        VoteCount = po.VoteCount,
                    }).ToList()
                });
            }

            return aggregatedPollDetails;
        }

        public async Task<PollDetailsDto> GetPoll(long pollId)
        {
            var poll = await _context.Polls.Where(x=>x.PollId == pollId).FirstOrDefaultAsync();

            var pollOptions = await _context.PollOptions
                                            .Where(po => pollId == pollId)
                                            .ToListAsync();

            var host = _configuration["GateWayService:Host"];
            var port = _configuration["GatewayService:Port"];

            var baseAddress = $"https://{host}:{port}/";
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(baseAddress);

            var userResponse = await client.GetAsync($"/user/{poll.UserId}");
            userResponse.EnsureSuccessStatusCode();
            var userDetails = await userResponse.Content.ReadAsAsync<UserDetailDto>();

            var aggregatedPollDetails = new PollDetailsDto
            {
                PollId = poll.PollId,
                UserId = poll.UserId,
                Title = poll.Title,
                Description = poll.Description,
                FirstName = userDetails.FirstName,
                LastName = userDetails.LastName,
                ExpiryDate = poll.ExpiryDate,
                PollOptions = pollOptions.Select(po => new PollOptions
                {
                    PollOptionId = po.PollOptionId,
                    PollId = po.PollId,
                    OptionText = po.OptionText,
                    PollImage = po.PollImage,
                    VoteCount = po.VoteCount,
                }).ToList()
            };

            return aggregatedPollDetails;
        }

        public async Task<long> AddPoll(AddPollOptionsDto pollDetails)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    Poll poll = new Poll();
                    poll.Title = pollDetails.Title;
                    poll.Description = pollDetails.Description;
                    poll.UserId = pollDetails.UserId;
                    poll.IsActive = pollDetails.IsActive;
                    poll.CreatedBy = 1;
                    poll.CreatedDate = DateTime.Now;
                    poll.ModifiedBy = 1;
                    poll.ModifiedDate = DateTime.Now;
                    poll.ExpiryDate = pollDetails.ExpiryDate;

                    _context.Polls.Add(poll);
                    await _context.SaveChangesAsync();

                    foreach(PollOptionsDetailDto pollOption in pollDetails.PollOptions) {
                        byte[] profileImage = null;
                        using (var ms = new MemoryStream())
                        {
                            if (pollOption.PollImage != null)
                            {
                                await pollOption.PollImage.CopyToAsync(ms);
                                profileImage = ms.ToArray();
                            }
                        }
                        var pollOptionEntity = new PollOptions
                        {
                            OptionText = pollOption.OptionText,
                            VoteCount = pollOption.VoteCount,
                            PollImage = profileImage,
                            CreatedBy = pollDetails.UserId,
                            CreatedDate = DateTime.Now,
                            ModifiedBy = pollDetails.UserId,
                            ModifiedDate = DateTime.Now,
                        };
                        _context.PollOptions.Add(pollOptionEntity);
                        await _context.SaveChangesAsync();
                    }

                    poll.CreatedBy = poll.UserId;
                    poll.ModifiedBy = poll.UserId;

                    _context.Polls.Update(poll);
                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();

                    return poll.PollId;

                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw ex;
                }
            }
        }

        public async Task<bool> UpdatePoll(AddPollOptionsDto pollDetails, long pollId)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var poll = await this._context.Polls.FirstOrDefaultAsync(x => x.PollId == pollId);
                    poll.Description = pollDetails.Description;
                    poll.Title = pollDetails.Title;
                    poll.ModifiedBy = pollDetails.ModifiedBy;
                    poll.ModifiedDate = DateTime.Now;
                    poll.ExpiryDate = pollDetails.ExpiryDate;

                    await _context.SaveChangesAsync();

                    foreach(PollOptionsDetailDto pollOptions in pollDetails.PollOptions)
                    {
                       var pollOption = await this._context.PollOptions.FirstOrDefaultAsync(x => x.PollId == pollId && x.PollOptionId == pollOptions.PollOptionId);
                        if ((bool)pollOptions.isImageUpdated)
                        {
                            byte[] profileImage = null;
                            using (var ms = new MemoryStream())
                            {
                                if (pollOptions.PollImage != null)
                                {
                                    await pollOptions.PollImage.CopyToAsync(ms);
                                    profileImage = ms.ToArray();
                                }
                            }
                            pollOption.PollImage = profileImage;
                        }
                        pollOption.OptionText = pollOptions.OptionText;
                        pollOption.VoteCount = pollOptions.VoteCount;
                        pollOption.ModifiedBy = pollDetails.UserId;
                        pollOption.ModifiedDate = DateTime.Now;

                        await _context.SaveChangesAsync();
                    }

                    await transaction.CommitAsync();

                    return true;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw ex;
                }
            }
        }

        public async Task<bool> DeletePoll(long pollId)
        {
            try
            {
                List<long> pollIdList = new List<long>();
                pollIdList.Add(pollId);
                if (await DeleteVoteByPollId(pollIdList))
                {
                    bool isDeletePoll = true;
                    var sqlQuery = $"Exec spDeletePoll {pollId}, {isDeletePoll}";
                    await _context.Database.ExecuteSqlRawAsync(sqlQuery);
                    return true;
                }
                throw new Exception("An Unexpected error occured in deleting votes");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeletePollOption(long pollId, long pollOptionId)
        {
            try
            {
                if (await DeleteVoteByPollOptionId(pollOptionId))
                {
                    bool isDeletePoll = false;
                    var sqlQuery = $"Exec spDeletePoll {pollId}, {isDeletePoll}";
                    await _context.Database.ExecuteSqlRawAsync(sqlQuery);
                    return true;
                }
                throw new Exception("An Unexpected error occured in deleting votes");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ValidatePollOption(long pollOptionId)
        {
            var pollOption = await _context.PollOptions.FindAsync(pollOptionId);
            if(pollOption != null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateVoteCount(long pollOptionId, bool isAdd)
        {
            try
            {
                var poll = await _context.PollOptions.FindAsync(pollOptionId);
                if (isAdd)
                {
                    poll.VoteCount += 1;
                }
                else
                {
                    poll.VoteCount -= 1;
                }
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteVoteByPollId(List<long> pollIds)
        {
            var host = _configuration["GatewayService:Host"];
            var port = _configuration["GatewayService:Port"];

            var baseAddress = $"https://{host}:{port}/";
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(baseAddress);

            var response = await client.PostAsJsonAsync($"/vote/poll/", pollIds);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteVoteByPollOptionId(long pollOptionId)
        {
            var host = _configuration["GatewayService:Host"];
            var port = _configuration["GatewayService:Port"];

            var baseAddress = $"https://{host}:{port}/";
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(baseAddress);

            var response = await client.GetAsync($"/vote/polloption/{pollOptionId}");

            return response.IsSuccessStatusCode;
        }
        #endregion
    }
}
