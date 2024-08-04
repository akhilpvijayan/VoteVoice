using Microsoft.AspNetCore.SignalR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System;
using NotificationService.Data;
using NotificationService.Models;
using NotificationService.Business.Services;

namespace NotificationService.Helper
{
    public class NotificationHub : Hub
    {
        #region properties
        private readonly DataContext _context;
        private readonly INotificationService _notificationService;
        #endregion

        #region constructor
        public NotificationHub(DataContext context, INotificationService notificationService)
        {
            this._context = context;
            _notificationService = notificationService;
        }
        #endregion

        #region public functions
        public async Task SendNotification(long targetUser, string message)
        {
            if(_notificationService.AddNotification(targetUser, message).Result)
            {
                await Clients.All.SendAsync("ReceiveNotification", targetUser, message);
            }
        }
        #endregion
    }
}