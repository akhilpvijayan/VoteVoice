namespace NotificationService.RabbitMQ.ProducerModel
{
    public class NotificationEvent
    {
        public long TargetUser { get; set; }
        public string Message { get; set; }
    }
}
