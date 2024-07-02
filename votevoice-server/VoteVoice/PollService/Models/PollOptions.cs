using PollService.Business.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PollService.Models
{
    public class PollOptions : BaseEntity, IPollOptions
    {
        [Key]
        public long PollOptionId { get; set; }

        [Required]
        [ForeignKey("Poll")]
        public long PollId { get; set; }

        [Required]
        public string OptionText { get; set; }

        public long VoteCount { get; set; } = 0;

        [Required]
        public byte[] PollImage { get; set; }

        public Poll Poll { get; set; }
    }
}
