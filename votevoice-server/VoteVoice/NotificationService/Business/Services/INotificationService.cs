using NotificationService.Business.Services.Dto;
using NotificationService.Models;

namespace NotificationService.Business.Services
{
    public interface INotificationService
    {
        Task<List<Notification>> GetAllNotificationsByUserAsync(long userId, int skip, int take);
        Task<List<Notification>> GetNotificationsForPreview(long userId);
        Task<Notification> AddNotification(NotificationDto notification);
    }
}
