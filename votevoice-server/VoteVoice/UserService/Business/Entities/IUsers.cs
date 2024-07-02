using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UserService.Business.Entities
{
    public interface IUsers
    {
        long UserId { get; set; }

        string Username { get; set; }

        string Email { get; set; }

        string Password { get; set; }

        DateTime LastLogin { get; set; }

        DateTime CreatedDate { get; set; }

        public bool IsActive { get; set; }

        bool IsVerified { get; set; }

        long RoleId { get; set; }

        string? RefreshToken { get; set; }

        DateTime RefreshTokenExpiry { get; set; }
    }
}
