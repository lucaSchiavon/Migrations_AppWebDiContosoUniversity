using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AppWebDiContosoUniversity.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AppWebDiContosoUniversity
{
    //https://docs.microsoft.com/it-it/aspnet/core/data/ef-mvc/complex-data-model?view=aspnetcore-3.1
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                //contenitore di inserimento delle dipendenze:
                var services = scope.ServiceProvider;
                try
                {
                    //Ottenere un'istanza del contesto di database dal contenitore di inserimento delle dipendenze
                    var context = services.GetRequiredService<SchoolContext>();
                    //inizializzare i dati
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
