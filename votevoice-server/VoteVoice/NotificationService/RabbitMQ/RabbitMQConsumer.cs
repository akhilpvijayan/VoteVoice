using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.SignalR;
using NotificationService.Business.Services;
using NotificationService.Helper;
using NotificationService.RabbitMQ.ProducerModel;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace NotificationService.RabbitMQ
{
    public class RabbitMQConsumer : BackgroundService
    {
        private readonly IHubContext<NotificationHub> _hubContext;
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IServiceProvider _serviceProvider;

        public RabbitMQConsumer(IHubContext<NotificationHub> hubContext, IServiceProvider serviceProvider)
        {
            _hubContext = hubContext;
            var factory = new ConnectionFactory() { HostName = "localhost" };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "notification_queue", durable: false, exclusive: false, autoDelete: false, arguments: null);
            _serviceProvider = serviceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken cancellationToken)
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var notificationEvent = JsonSerializer.Deserialize<NotificationEvent>(message);

                if (notificationEvent != null)
                {
                    await ProcessNotification(notificationEvent);
                }
            };

            _channel.BasicConsume(queue: "notification_queue", autoAck: true, consumer: consumer);

            return Task.CompletedTask;
        }

        private async Task ProcessNotification(NotificationEvent notificationEvent)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var notificationService = scope.ServiceProvider.GetRequiredService<INotificationService>();

                try
                {
                    var result = await notificationService.AddNotification(notificationEvent.TargetUser, notificationEvent.Message);
                    if (result)
                    {
                        await SendNotification(notificationEvent.TargetUser, notificationEvent.Message);
                    }
                }
                catch (Exception ex)
                {
                    // Log or handle the exception as necessary
                    throw;
                }
            }
        }


        private async Task SendNotification(long targetUser, string message)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveNotification", targetUser, message);
        }

        public override void Dispose()
        {
            _channel.Close();
            _connection.Close();
            base.Dispose();
        }
    }
}
