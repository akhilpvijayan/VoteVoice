using System.Text.Json;
using System.Text;
using RabbitMQ.Client;
using PollService.RabbitMQ.PublisherModel;

namespace PollService.RabbitMQ
{
    public class RabbitMQPublisher
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMQPublisher()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "notification_queue", durable: false, exclusive: false, autoDelete: false, arguments: null);
        }

        public void Publish(NotificationEvent notificationEvent)
        {
            var message = JsonSerializer.Serialize(notificationEvent);
            var body = Encoding.UTF8.GetBytes(message);

            _channel.BasicPublish(exchange: "", routingKey: "notification_queue", basicProperties: null, body: body);
        }
    }
}
