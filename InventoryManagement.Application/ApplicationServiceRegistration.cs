using InventoryManagement.Application.Contracts.Features;
using InventoryManagement.Application.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace InventoryManagement.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection ConfigureApplicationService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITrackItemQuantity, TrackItemQuantity>();
            services.AddScoped<IUpdateQuantity, UpdateQuantity>();
            return services;
        }
    }


}
