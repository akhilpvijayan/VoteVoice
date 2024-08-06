using NotificationService.Business.Services.Dto;

namespace NotificationService.RabbitMQ.ProducerModel
{
    public class NotificationEvent
    {
        public NotificationDto Notification { get; set; }
    }
}
