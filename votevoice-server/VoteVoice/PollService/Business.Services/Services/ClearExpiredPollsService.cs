using PollService.Data;
using PollService.Models;

namespace PollService.Business.Services.Services
{
    public class ClearExpiredPollsService : IHostedService, IDisposable
    {
        private Timer _timer;
        private readonly ILogger<ClearExpiredPollsService> _logger;
        private readonly IServiceScopeFactory _scopeFactory;

        public ClearExpiredPollsService(ILogger<ClearExpiredPollsService> logger, IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("ClearExpiredPollsService is starting.");

            // Schedule the task to run once a day
            _timer = new Timer(ClearExpiredPolls, null, TimeSpan.Zero, TimeSpan.FromDays(1));

            return Task.CompletedTask;
        }

        private async void ClearExpiredPolls(object state)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();

                var currentDate = DateTime.UtcNow;
                var expiredPolls = dbContext.Polls.Where(p => p.ExpiryDate < currentDate);

                if (expiredPolls.Any())
                {
                    var pollService = scope.ServiceProvider.GetRequiredService<IPollService>();
                    var pollIds = expiredPolls.Select(p => p.PollId).ToList();
                    await pollService.DeleteVoteByPollId(pollIds);

                    dbContext.Polls.RemoveRange(expiredPolls);
                    dbContext.SaveChanges();
                    _logger.LogInformation($"{expiredPolls.Count()} expired polls have been removed.");
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("ClearExpiredPollsService is stopping.");
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
