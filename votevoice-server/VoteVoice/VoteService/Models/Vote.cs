using System.ComponentModel.DataAnnotations;
using VoteService.Business.Entities;

namespace VoteService.Models
{
    public class Vote : IVote
    {
        [Key]
        public long VoteId { get; set; }

        [Required]
        public long PollOptionId { get; set; }

        [Required]
        public long UserId { get; set; }

        [Required]
        public long PollId { get; set; }

        public DateTime? CreatedDate { get; set; } = DateTime.Now;
    }
}
