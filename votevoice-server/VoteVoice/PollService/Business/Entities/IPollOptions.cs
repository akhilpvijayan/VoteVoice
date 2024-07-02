using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PollService.Models;

namespace PollService.Business.Entities
{
    public interface IPollOptions
    {
        long PollOptionId { get; set; }
        long PollId { get; set; }
        string OptionText { get; set; }
        long VoteCount { get; set; }
        byte[] PollImage { get; set; }
    }
}
