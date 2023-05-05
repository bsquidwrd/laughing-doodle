using laughing_doodle;
using MassTransit;
using System.Reflection;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddMassTransit(x =>
        {
            x.SetKebabCaseEndpointNameFormatter();

            var entryAssembly = Assembly.GetEntryAssembly();

            x.AddConsumers(entryAssembly);

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host("localhost", "/", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                cfg.UseMessageRetry(r =>
                {
                    r.Interval(5, TimeSpan.FromSeconds(5));
                });

                cfg.ConfigureEndpoints(context, new KebabCaseEndpointNameFormatter(includeNamespace: true));
            });
        });

        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
