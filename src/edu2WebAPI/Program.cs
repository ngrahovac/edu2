using edu2WebAPI.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace edu2WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // reset db data on startup
            // alternatively: migrate via console after running tests
            /*
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddUserSecrets("4870057d-6276-462b-bbd7-fdee159ab323");
            var configuration = builder.Build();

            using (var dbContext = new Edu2DbContext(configuration))
            {
                dbContext.Database.EnsureDeleted();
                dbContext.Database.Migrate();
            }
            */

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
