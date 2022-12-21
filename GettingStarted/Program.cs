using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MassTransit;

namespace GettingStarted
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddMassTransit(x =>
                    {
                        x.AddConsumer<MessageConsumer>();
                        x.SetKebabCaseEndpointNameFormatter();
                        x.UsingRabbitMq((context, cfg) =>
                        {
                            // adjust as per local rabbitmq setup
                            cfg.Host("localhost",
                                h =>
                                {
                                    h.Username("dias");
                                    h.Password("dias");
                                });
                            cfg.UseSendFilter(typeof(DelaySendFilter<>), context);
                            cfg.ConfigureEndpoints(context);
                        });
                    });
                    EndpointConvention.Map<Message>(
                        new Uri($"queue:{KebabCaseEndpointNameFormatter.Instance.SanitizeName(nameof(Message))}"));

                    services.AddHostedService<Worker>();
                });
    }
}