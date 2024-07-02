using VoteService.Models;

namespace VoteService.Business.Services
{
    public interface IVoteService
    {
        Task<long> AddVote(Vote voteDetails);
        Task<long> GetVotesCount(long pollOptionId);
    }
}
