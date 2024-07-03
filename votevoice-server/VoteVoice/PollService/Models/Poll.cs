using PollService.Business.Entities;
using System.ComponentModel.DataAnnotations;

namespace PollService.Models
{
    public class Poll : BaseEntity, IPoll
    {
        [Key]
        public long PollId { get; set; }

        public long UserId { get; set; } // Reference to User Service

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime ExpiryDate { get; set; }
    }

}
