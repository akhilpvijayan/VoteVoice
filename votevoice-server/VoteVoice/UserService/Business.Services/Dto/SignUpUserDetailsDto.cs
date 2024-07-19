using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using UserService.Models;

namespace UserService.Business.Services.Dto
{
    [Keyless]
    public class SignUpUserDetailsDto
    {
        public long? UserId { get; set; } = null;

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime? LastLogin { get; set; } = DateTime.Now;

        public DateTime? CreatedDate { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;

        public bool IsVerified { get; set; } = false;

        public long RoleId { get; set; }

        public long? UserDetailId { get; set; } = null;

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [NotMapped]
        public string? ProfileImage { get; set; } = null;

        public string UserBio { get; set; }

        public string Gender { get; set; }

        public long CountryId { get; set; }

        public long StateId { get; set; }

        public string? Region { get; set; } = null;

        public int? FollowersCount { get; set; } = 0;
    }
}
