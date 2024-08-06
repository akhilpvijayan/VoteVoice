using Microsoft.EntityFrameworkCore;
using NotificationService.Data;
using NotificationService.Models;

namespace NotificationService.XObjects.SeedScripts
{
    public static class SeedDataExtension
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<DataContext>();
            #region Notification Types
            if (await context.NotificationTypes.FirstOrDefaultAsync(x => x.NotificationTypeName == "Add Vote") == null)
            {
                context.NotificationTypes.AddRange(new NotificationType { NotificationTypeName = "Add Vote" , NotificationMessage = " added a new vote."});
            }
            if (await context.NotificationTypes.FirstOrDefaultAsync(x => x.NotificationTypeName == "Connection") == null)
            {
                context.NotificationTypes.AddRange(new NotificationType { NotificationTypeName = "Connection", NotificationMessage = " started following you." });
            }
            if (await context.NotificationTypes.FirstOrDefaultAsync(x => x.NotificationTypeName == "Comment") == null)
            {
                context.NotificationTypes.AddRange(new NotificationType { NotificationTypeName = "Comment", NotificationMessage = " added a new comment." });
            }
            await context.SaveChangesAsync();
            #endregion
        }
    }
}
