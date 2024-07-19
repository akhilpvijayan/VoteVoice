using Microsoft.EntityFrameworkCore;
using PollService.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace PollService.Business.Services.Dto
{
    [Keyless]
    public class PollOptionsDetailDto : BaseEntity
    {
        public long? PollOptionId { get; set; } = null;

        public string OptionText { get; set; }

        public long VoteCount { get; set; }

        [NotMapped]
        public string? PollImage { get; set; }

        public bool? isImageUpdated { get; set; } = false;
    }
}
