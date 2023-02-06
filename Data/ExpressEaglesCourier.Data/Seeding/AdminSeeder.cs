namespace ExpressEaglesCourier.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Common;
    using ExpressEaglesCourier.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public class AdminSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            UserManager<ApplicationUser> adminSeeder = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            if (await adminSeeder.Users.AnyAsync(u => u.Email == "admin@expresseagles.com"))
            {
                return;
            }

            IdentityResult result = await adminSeeder.CreateAsync(
                new ApplicationUser
                {
                    UserName = "Admin",
                    Email = "admin@expresseagles.com",
                    PhoneNumber = "00359889694030",
                    PhoneNumberConfirmed = true,
                    EmailConfirmed = true,
                },
                "admin200115");

            if (result.Succeeded)
            {
                ApplicationUser user = await adminSeeder.FindByNameAsync("Admin");
                await adminSeeder.AddToRoleAsync(user, GlobalConstants.AdministratorRoleName);
            }
        }
    }
}
