using Microsoft.AspNetCore.Hosting;
using Catalog.Infrastructure.Contexts;
using Catalog.WebAPIServer.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Catalog.WebAPIServer
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
           // var builder = WebApplication.CreateBuilder(args);
            var host = CreateHostBuilder(args).Build();            
            
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<CatalogContext>();

                    if (context.Database.IsSqlServer())
                    {
                        context.Database.Migrate();
                    }
                }
                catch (Exception ex)
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

                    logger.LogError(ex, "Se produjo un error al migrar o inicializar la base de datos.");

                    throw;
                }
            }

            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStaticWebAssets();
                    webBuilder.UseStartup<Startup>();
                });
    }
}