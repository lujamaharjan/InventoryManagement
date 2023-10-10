using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using InventoryManagement.Infrastructure.Queue.Contracts;
using InventoryManagement.Infrastructure.Queue.Service;

namespace InventoryManagement.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection ConfigureInfrastructureService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IMessageQueueService>(provider=> new MessageQueueService(configuration["RabbitMQ:HostName"]));
        return services;
    }
}
