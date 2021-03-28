using MassTransit;
using Messaginator.Receiver.Message;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Messaginator.Receiver.AppStart
{
    public static class MassTransitConfig
    {
        public static IServiceCollection AddAndConfigureMassTransit(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(cfg =>
            {
                cfg.UsingRabbitMq((context, configurator) =>
                {
                    configurator.Host(configuration["RabbitMq:Host"], host =>
                    {
                        host.Username(configuration["RabbitMq:User"]);
                        host.Password(configuration["RabbitMq:Password"]);
                    });
                    
                    cfg.AddConsumer<MessagesConsumer>();

                    configurator.ReceiveEndpoint(e =>
                    {
                        e.ConfigureConsumers(context);
                    });
                });
            });
            services.AddMassTransitHostedService();

            return services;
        }
    }
}