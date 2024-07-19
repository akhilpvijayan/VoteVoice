using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using PollService.Models;

namespace PollService.Business.Services.Dto
{
    [Keyless]
    public class UserDetailDto : BaseEntity
    {
        public long UserId { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public DateTime LastLogin { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsActive { get; set; } = true;

        public bool IsVerified { get; set; } = false;

        public long RoleId { get; set; }

        public string RoleName { get; set; }

        public long UserDetailId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string? ProfileImage { get; set; }

        public string UserBio { get; set; }

        public string Gender { get; set; }

        public long CountryId { get; set; }

        public string Country { get; set; }

        public long StateId { get; set; }

        public string State { get; set; }

        public string? Region { get; set; }

        public int FollowersCount { get; set; }
    }
}
