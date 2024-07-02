using System.ComponentModel.DataAnnotations;

namespace UserService.Models
{
    public class BaseEntity
    {
        #region properties
        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public long CreatedBy { get; set; }

        [Required]
        public DateTime ModifiedDate { get; set; }

        [Required]

        public long ModifiedBy { get; set; }
        #endregion
    }
}
