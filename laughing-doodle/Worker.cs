using laughing_doodle.Models;
using MassTransit;

namespace laughing_doodle
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IBus _bus;

        public Worker(ILogger<Worker> logger, IBus bus)
        {
            _logger = logger;
            _bus = bus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await _bus.Publish<MyModel1>(new() { MyValue = "bsquidwrd", Timestamp = DateTime.UtcNow }, stoppingToken);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
