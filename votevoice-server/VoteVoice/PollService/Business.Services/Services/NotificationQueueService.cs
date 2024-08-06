using Microsoft.EntityFrameworkCore;
using PollService.Business.Services.Dto;
using PollService.Data;
using PollService.Enums;
using PollService.Models;
using PollService.RabbitMQ;
using PollService.RabbitMQ.PublisherModel;

namespace PollService.Business.Services.Services
{
    public class NotificationQueueService : IHostedService, IDisposable
    {
        private Timer _timer;
        private readonly ILogger<ClearExpiredPollsService> _logger;
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly RabbitMQPublisher _rabbitMQPublisher;
        private readonly IServiceProvider _serviceProvider;
        private readonly IServiceScopeFactory _scopeFactory;

        public NotificationQueueService(ILogger<ClearExpiredPollsService> logger, IConfiguration configuration, IHttpClientFactory httpClientFactory, RabbitMQPublisher rabbitMQPublisher, IServiceProvider serviceProvider, IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            _rabbitMQPublisher = rabbitMQPublisher;
            _serviceProvider = serviceProvider;
            _scopeFactory = scopeFactory;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public async void SendNotifications(Poll poll, string token)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                try
                {
                    var context = scope.ServiceProvider.GetRequiredService<DataContext>();
                    var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();
                    var httpClientFactory = scope.ServiceProvider.GetRequiredService<IHttpClientFactory>();
                    var rabbitMQPublisher = scope.ServiceProvider.GetRequiredService<RabbitMQPublisher>();
                    var pollService = scope.ServiceProvider.GetRequiredService<IPollService>();
                    //Get poll details
                    var pollDetails = await pollService.GetPoll(poll.PollId);

                    var host = _configuration["GateWayService:Host"];
                    var port = _configuration["GatewayService:Port"];

                    var baseAddress = $"https://{host}:{port}/";
                    var client = _httpClientFactory.CreateClient();
                    client.BaseAddress = new Uri(baseAddress);

                    //Remove if bearer already exists in token
                    if (token.StartsWith("bearer ", StringComparison.OrdinalIgnoreCase))
                    {
                        token = token.Substring("bearer ".Length).Trim();
                    }

                    //Adding Bearer to token
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                    var userResponse = await client.GetAsync($"/vote/poll/{poll.PollId}");
                    userResponse.EnsureSuccessStatusCode();

                    //Get all users voted for the poll
                    var userIds = await userResponse.Content.ReadFromJsonAsync<List<long>>();

                    if (pollDetails?.PollId != null)
                    {
                        foreach (var userId in userIds)
                        {
                            if (poll.UserId != userId)
                            {
                                NotificationDto notification = new NotificationDto
                                {
                                    TargetUserId = userId,
                                    UserId = poll.UserId,
                                    PollId = poll.PollId,
                                    FirstName = pollDetails.FirstName,
                                    LastName = pollDetails.LastName,
                                    profileImage = pollDetails.ProfileImage,
                                    NotificationTypeId = (long)NotificationTypeEnum.Update
                                };
                                var notificationEvent = new NotificationEvent { Notification = notification };
                                _rabbitMQPublisher.Publish(notificationEvent);
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
