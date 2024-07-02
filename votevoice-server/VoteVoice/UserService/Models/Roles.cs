using System.ComponentModel.DataAnnotations;
using UserService.Business.Entities;

namespace UserService.Models
{
    public class Roles : IRoles
    {
        [Key]
        public long RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
