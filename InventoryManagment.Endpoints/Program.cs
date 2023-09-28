using InventoryManagement.Persistance;
namespace InventoryManagment.Endpoints
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.ConfigurePersistanceService(builder.Configuration);
            var app = builder.Build();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.Run();
        }
    }
}