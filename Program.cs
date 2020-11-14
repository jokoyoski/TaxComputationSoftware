using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using TaxComputationAPI.Data;
using TaxComputationAPI.Manager;
using TaxComputationAPI.Models;

namespace TaxComputationAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host =  CreateHostBuilder(args).Build();
           using (var scope = host.Services.CreateScope())
           {
               var services = scope.ServiceProvider;
               try
               {
                    var dbContext = services.GetRequiredService<DatabaseManager>();
                   // var context = services.GetRequiredService<DataContext>();
                    //var userManager = services.GetRequiredService<UserManager<User>>();
                   // var roleManager = services.GetRequiredService<RoleManager<Role>>();
                    //context.Database.Migrate();
                   // Seed.SeedUsers(userManager, roleManager);
                    dbContext.UpdateProcedure();
                  
               }
               catch (Exception ex)
               {
                   var logger = services.GetRequiredService<ILogger<Program>>();
                   logger.LogError(ex, "An error occured during migration");
               }
           }

           host.Run(); 
        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args) .UseSerilog((ctx, config) => { config.ReadFrom.Configuration(ctx.Configuration); })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                    .UseUrls("http://*:5000");
                });

       
    }
}
