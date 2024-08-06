
using PollService.Business.Services.Dto;

namespace PollService.RabbitMQ.PublisherModel
{
    public class NotificationEvent
    {
        public NotificationDto Notification { get; set; }
    }
}
