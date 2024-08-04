using NotificationService.Data;
using NotificationService.Models;

namespace NotificationService.Business.Services.Services
{
    public class NotificationService : INotificationService
    {
        private readonly DataContext _context;

        #region constructor
        public NotificationService(DataContext context)
        {
            this._context = context;
        }
        #endregion

        #region public functions
        public async Task<bool> AddNotification(long targetUser, string message)
        {
            try
            {

                Notification notifications = new Notification
                {
                    Message = message,
                    CreatedAt = DateTime.Now,
                    TargetUserId = targetUser,
                };
                await _context.Notifications.AddAsync(notifications);
                await _context.SaveChangesAsync();
                return notifications.NotificationId > 0 ? true : false;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
