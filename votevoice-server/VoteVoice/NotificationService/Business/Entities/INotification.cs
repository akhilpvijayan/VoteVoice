using System.ComponentModel.DataAnnotations;

namespace NotificationService.Business.Entities
{
    public interface INotification
    {
        int NotificationId { get; set; }

        string Message { get; set; }

        DateTime CreatedAt { get; set; }

        bool IsRead { get; set; }

        long TargetUserId { get; set; }
    }
}
