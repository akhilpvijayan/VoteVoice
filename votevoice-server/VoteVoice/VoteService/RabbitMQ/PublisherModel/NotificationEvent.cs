using VoteService.Business.Services.Dto;

namespace VoteService.RabbitMQ.ProducerModel
{
    public class NotificationEvent
    {
        public NotificationDto Notification { get; set; }
    }
}
