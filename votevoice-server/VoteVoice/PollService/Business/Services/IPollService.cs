using PollService.Business.Services.Dto;

namespace PollService.Business.Services
{
    public interface IPollService
    {
        Task<IEnumerable<PollDetailsDto>> GetAllPolls(int skip, int take);
        Task<PollDetailsDto> GetPoll(long pollId);
        Task<long> AddPoll(AddPollOptionsDto pollDetails);
        Task<bool> UpdatePoll(AddPollOptionsDto pollDetails, long pollId);
        Task<bool> DeletePoll(long pollId);
        Task<bool> DeletePollOption(long pollId, long pollOptionId);
        Task<bool> ValidatePollOption(long pollOptionId);
        Task<bool> UpdateVoteCount(long pollOptionId, bool isAdd);
        Task<bool> DeleteVoteByPollId(List<long> pollId);
        Task<bool> DeleteVoteByPollOptionId(long pollOptionId);
    }
}
