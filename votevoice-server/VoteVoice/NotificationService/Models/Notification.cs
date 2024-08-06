using NotificationService.Business.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public long? UserId { get; set; }

        public long? PollId { get; set; }

        public string? firstName { get; set; }

        public string? lastName { get; set; }

        public string? profileImage { get; set; }

        [Required]
        [ForeignKey("NotificationType")]
        public long NotificationTypeId { get; set; }

        public NotificationType NotificationType { get; set; }
    }
}
