using Microsoft.EntityFrameworkCore;
using NotificationService.Business.Services.Dto;
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
        public async Task<List<Notification>> GetAllNotificationsByUserAsync(long userId, int skip, int take)
        {
            return await _context.Notifications.Where(x=>x.TargetUserId == userId)
                                                            .OrderByDescending(p => p.CreatedAt)
                                                            .Skip(skip)
                                                            .Take(take)
                                                            .ToListAsync();
        }

        public async Task<List<Notification>> GetNotificationsForPreview(long userId)
        {
            return await _context.Notifications.Where(x => x.TargetUserId == userId)
                                                            .OrderByDescending(p => p.CreatedAt)
                                                            .Skip(0)
                                                            .Take(3)
                                                            .ToListAsync();
        }

        public async Task<Notification> AddNotification(NotificationDto notification)
        {
            try
            {
                var notificationType = await _context.NotificationTypes.FirstOrDefaultAsync(x => x.NotificationTypeId == notification.NotificationTypeId);
                Notification notifications = new Notification
                {
                    Message = notificationType.NotificationMessage,
                    CreatedAt = DateTime.Now,
                    TargetUserId = notification.TargetUserId,
                    PollId = notification.PollId,
                    UserId = notification.UserId,
                    firstName = notification.FirstName,
                    lastName = notification.LastName,
                    profileImage = notification.profileImage
                };
                await _context.Notifications.AddAsync(notifications);
                await _context.SaveChangesAsync();
                return notifications;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
