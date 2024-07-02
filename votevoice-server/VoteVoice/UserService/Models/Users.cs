using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using UserService.Business.Entities;
using UserService.Models;

namespace UserService.Models
{
    public class Users : BaseEntity, IUsers
    {
        [Key]
        public long UserId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public DateTime LastLogin { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Required]
        public bool IsActive { get; set; } = true;

        public bool IsVerified { get; set; } = false;

        [ForeignKey("Role")]
        public long RoleId { get; set; }

        public string? RefreshToken { get; set; } = null;

        public DateTime RefreshTokenExpiry { get; set; }

        public Roles Role { get; set; }
    }
}