using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotificationService.Business.Services;

namespace NotificationService.Controllers
{
    [Route("notification")]
    public class NotificationController : Controller
    {
        #region properties
        private readonly INotificationService _notificationService;
        #endregion

        #region constructor
        public NotificationController(INotificationService notification)
        {
            this._notificationService = notification;
        }

        #endregion
        [Authorize]
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetNotificationsByUserId(long userId, [FromQuery] int skip, [FromQuery] int take)
        {
            try
            {
                var result = await _notificationService.GetAllNotificationsByUserAsync(userId, skip, take);
                if (result != null)
                {
                    return Ok(result); ;
                };
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [Authorize]
        [HttpGet("preview/{userId}")]
        public async Task<IActionResult> GetNotificationsForPreview(long userId)
        {
            try
            {
                var result = await _notificationService.GetNotificationsForPreview(userId);
                if (result != null)
                {
                    return Ok(result); ;
                };
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
