using NotificationService.Business.Entities;
using System.ComponentModel.DataAnnotations;

namespace NotificationService.Models
{
    public class Notification : INotification 
    {
        [Key]
        public int NotificationId { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public bool IsRead { get; set; } = false;

        [Required]
        public long TargetUserId { get; set; }
    }
}
