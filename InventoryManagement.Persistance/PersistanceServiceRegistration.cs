using InventoryManagement.Application.Contracts.Persistance;
using InventoryManagement.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace InventoryManagement.Persistance
{
    public static class PersistanceServiceRegistration
    {
        public static IServiceCollection ConfigurePersistanceService(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<InventoryManagementDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("InventoryManagementConnectionString")));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryItemRepository, CategoryItemRepository>();
            services.AddScoped<ITransactionHistoryRepository, TransactionHistoryRepository>();
            return services;
        }

    }
}
