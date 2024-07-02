using System.ComponentModel.DataAnnotations;

namespace PollService.Models
{
    public class BaseEntity
    {
        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public long CreatedBy { get; set; }

        [Required]
        public DateTime ModifiedDate { get; set; }

        [Required]

        public long ModifiedBy { get; set; }
    }
}
