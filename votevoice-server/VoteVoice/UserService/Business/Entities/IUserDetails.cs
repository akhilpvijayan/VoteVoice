using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UserService.Business.Entities
{
    public interface IUserDetails
    {
        long UserDetailId { get; set; }

        long UserId { get; set; }

        public string FirstName { get; set; }

        string LastName { get; set; }

        byte[]? ProfileImage { get; set; }

        string UserBio { get; set; }

        string Gender { get; set; }

        long? CountryId { get; set; }

        long? StateId { get; set; }

        string Region { get; set; }

        int? FollowersCount { get; set; }
    }
}
