namespace NotificationService.Business.Services
{
    public interface INotificationService
    {
        Task<bool> AddNotification(long targetUser, string message);
    }
}
