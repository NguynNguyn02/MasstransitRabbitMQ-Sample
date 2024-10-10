using MassTransit;
using MasstransitRabbitMQ_Sample.Comsumer.API.DependencyInjection.Options;
using MasstransitRabbitMQ_Sample.Comsumer.API.MessageBus.Consumers.Event;
using System.Reflection;

namespace MasstransitRabbitMQ_Sample.Comsumer.API.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddMediatR(this IServiceCollection services) =>
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

        public static IServiceCollection AddconfigureMasstractionRabbitMQ(this IServiceCollection services, IConfiguration configuration)
        {
            var masstransitConfiguration = new MasstransitConfiguration();
            configuration.GetSection(nameof(masstransitConfiguration)).Bind(masstransitConfiguration);

            services.AddMassTransit(mt =>
            {

                mt.AddConsumers(Assembly.GetExecutingAssembly());

                mt.UsingRabbitMq((context, bus) =>
                {
                    bus.Host(masstransitConfiguration.Host, masstransitConfiguration.VHost, h =>
                    {
                        h.Username(masstransitConfiguration.UserName);
                        h.Password(masstransitConfiguration.Password);
                    });
                    bus.ConfigureEndpoints(context);
                });
            });
            return services;
        }
    }
}
