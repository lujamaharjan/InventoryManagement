global using FastEndpoints;
global using FastEndpoints.Swagger;
using InventoryManagement.Application;
using InventoryManagement.Persistance;
namespace InventoryManagment.Endpoints
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddFastEndpoints();
            builder.Services.SwaggerDocument(o =>
            {
                o.DocumentSettings = s =>
                {
                    s.Title = "InventoryManagement API";
                    s.Version = "v1";
                };
            });

            builder.Services.ConfigureApplicationService(builder.Configuration);
            builder.Services.ConfigurePersistanceService(builder.Configuration);

            var app = builder.Build();
            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.UseFastEndpoints();
            app.UseSwaggerGen();
            
            app.Run();
        }
    }
}