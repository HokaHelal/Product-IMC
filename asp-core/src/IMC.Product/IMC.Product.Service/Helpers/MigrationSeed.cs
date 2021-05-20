using IMC.Product.Models;
using IMC.Product.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace IMC.Products.Service.Helpers
{
    public class MigrationSeed
    {
        public async static Task Invoke(IServiceProvider services)
        {
            var logger = services.GetRequiredService<ILogger<MigrationSeed>>();

            try
            {
                var context = services.GetRequiredService<DataContext>();
                var userManager = services.GetRequiredService<UserManager<AppUser>>();
                var roleManager = services.GetRequiredService<RoleManager<AppRole>>();
                logger.LogDebug("Start Migrate");
                await context.Database.MigrateAsync();
                logger.LogDebug("Start Seed LookUp");

                await Seed.SeedLookups(context);
                logger.LogDebug("Start Seed Users");
                await Seed.SeedUsers(userManager, roleManager, context);
                logger.LogDebug("Start Seed Forum");
                await Seed.SeedForum(context);                
            }
            catch (Exception ex)
            {             
                logger.LogError(ex, "An error occured during migration");
            }
        }
    }
}
