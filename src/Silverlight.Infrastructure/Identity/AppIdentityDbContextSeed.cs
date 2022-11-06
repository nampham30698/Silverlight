using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Silverlight.ApplicationCore.Constants;

namespace Silverlight.Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedAsync(AppIdentityDbContext identityDbContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {

            if (identityDbContext.Database.IsSqlServer())
            {
                identityDbContext.Database.Migrate();
            }

            await roleManager.CreateAsync(new IdentityRole(Constants.Roles.ADMINISTRATORS));

            var defaultUser = new ApplicationUser { UserName = "nampham@gmail.com", Email = "nampham@gmail.com" };
            await userManager.CreateAsync(defaultUser, Constants.Authorization.DEFAULT_PASSWORD);

            string adminUserName = "admin@gmail.com";
            var adminUser = new ApplicationUser { UserName = adminUserName, Email = adminUserName };
            await userManager.CreateAsync(adminUser, Constants.Authorization.DEFAULT_PASSWORD);
            adminUser = await userManager.FindByNameAsync(adminUserName);
            await userManager.AddToRoleAsync(adminUser, Constants.Roles.ADMINISTRATORS);
        }
    }
}
