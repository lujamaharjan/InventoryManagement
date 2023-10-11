using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using InventoryManagement.Infrastructure.Queue.Contracts;
using InventoryManagement.Infrastructure.Queue.Service;

namespace InventoryManagement.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection ConfigureInfrastructureService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IMessageQueueService>(provider=> new MessageQueueService(configuration["RabbitMQ:HostName"]??""));
        services.AddHostedService(provider =>
        {
            var rabbitMQHostName = configuration["RabbitMQ:HostName"]??"";
            var rabbitMQUsername = configuration["RabbitMQ:Username"]??"";
            var rabbitMQPassword = configuration["RabbitMQ:Password"]??"";

            return new EmailSender(rabbitMQHostName, rabbitMQUsername, rabbitMQPassword);
        });
        return services;
    }
}
