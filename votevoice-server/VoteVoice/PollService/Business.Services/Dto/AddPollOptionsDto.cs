using Microsoft.EntityFrameworkCore;
using PollService.Models;

namespace PollService.Business.Services.Dto
{
    [Keyless]
    public class AddPollOptionsDto : BaseEntity
    {
        public long UserId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public List<PollOptionsDetailDto> PollOptions { get; set; }
    }
}
