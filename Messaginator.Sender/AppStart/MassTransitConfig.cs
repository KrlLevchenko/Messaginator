using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Messaginator.Sender.AppStart
{
    public static class MassTransitConfig
    {
        public static IServiceCollection AddAndConfigureMassTransit(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(cfg =>
            {
                cfg.UsingRabbitMq((context, configurator) => configurator.Host(configuration["RabbitMq:Host"], host =>
                {
                    host.Username(configuration["RabbitMq:User"]);
                    host.Password(configuration["RabbitMq:Password"]);
                }));
            });
            
            return services;
        }
    }
}