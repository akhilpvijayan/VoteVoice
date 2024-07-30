using VoteService.Models;

namespace VoteService.Business.Services
{
    public interface IVoteService
    {
        Task<long> AddVote(Vote voteDetails, string token);
        Task<long> GetVotesCount(long pollOptionId);
        Task<bool> DeleteVotesByPollIds(List<long> pollIds);
        Task<bool> DeleteVoteByPollOptionId(long pollOptionId);
    }
}
