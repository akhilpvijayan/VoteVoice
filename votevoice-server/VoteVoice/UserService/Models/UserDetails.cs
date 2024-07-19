using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using UserService.Business.Entities;
using UserService.Models;

namespace UserService.Models
{
    public class UserDetails : BaseEntity, IUserDetails
    {
        [Key]
        public long UserDetailId { get; set; }

        [ForeignKey("User")]
        public long UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength]
        public string LastName { get; set; }

        public string? ProfileImage { get; set; } = null;

        [Required]
        [MaxLength(100)]
        public string UserBio { get; set; }


        [Required]
        public string Gender { get; set; }

        [ForeignKey("UserCountry")]
        public long? CountryId { get; set; }

        [ForeignKey("UserState")]
        public long? StateId { get; set; }

        public string Region { get; set; }

        public int? FollowersCount { get; set; } = 0;

        public Users User { get; set; }

        public Countries UserCountry { get; set; }

        public States UserState { get; set; }
    }
}