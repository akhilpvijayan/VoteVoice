using NotificationService.Business.Entities;
using System.ComponentModel.DataAnnotations;

namespace NotificationService.Models
{
    public class NotificationType : INotificationType
    {
        [Key]
        public long NotificationTypeId { get; set; }
        public string NotificationTypeName { get; set; }
        public string NotificationMessage { get; set; }
    }
}
