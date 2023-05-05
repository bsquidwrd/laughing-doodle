using laughing_doodle.Models;
using MassTransit;

namespace laughing_doodle.Consumers
{
    public class MyModel2Consumer : IConsumer<MyModel2>
    {
        private readonly ILogger<MyModel2Consumer> _logger;

        public MyModel2Consumer(ILogger<MyModel2Consumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<MyModel2> context)
        {
            _logger.LogInformation("Received message with value of : '{MyValue}' and a timestamp of {Timestamp}", context.Message.MyValue, context.Message.Timestamp);
            return Task.CompletedTask;
        }
    }
}
