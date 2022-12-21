namespace ExpressEaglesCourier.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Common;
    using ExpressEaglesCourier.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    internal class StaffUsersSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            UserManager<ApplicationUser> staffSeeder = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            if (staffSeeder.Users.Count() > 2)
            {
                return;
            }

            if (!staffSeeder.Users.Any(u => u.Email == "IvaStoyanova@expresseagles.com"))
            {
                Employee employee = dbContext.Employees.FirstOrDefault(x => x.PhoneNumber == "00359899313131");

                IdentityResult result = await staffSeeder.CreateAsync(
                    new ApplicationUser
                    {
                        UserName = "IvaStoyanova",
                        Email = "IvaStoyanova@expresseagles.com",
                        PhoneNumber = "00359899313131",
                        PhoneNumberConfirmed = true,
                        EmailConfirmed = true,
                        EmployeeId = employee.Id,
                    },
                    "IS123456##");

                if (result.Succeeded)
                {
                    ApplicationUser user = await staffSeeder.FindByNameAsync("IvaStoyanova");
                    await staffSeeder.AddToRoleAsync(user, GlobalConstants.EmployeeRoleName);
                    employee.ApplicationUserId = user.Id;
                }
            }

            if (!staffSeeder.Users.Any(u => u.Email == "DanielaStoilova@expresseagles.com"))
            {
                Employee employee = dbContext.Employees.FirstOrDefault(x => x.PhoneNumber == "00359888333333");

                IdentityResult result = await staffSeeder.CreateAsync(
                    new ApplicationUser
                    {
                        UserName = "DanielaStoilova",
                        Email = "DanielaStoilova@expresseagles.com",
                        PhoneNumber = "00359888333333",
                        PhoneNumberConfirmed = true,
                        EmailConfirmed = true,
                        EmployeeId = employee.Id,
                    },
                    "DS123456##");

                if (result.Succeeded)
                {
                    ApplicationUser user = await staffSeeder.FindByNameAsync("DanielaStoilova");
                    await staffSeeder.AddToRoleAsync(user, GlobalConstants.EmployeeRoleName);
                    employee.ApplicationUserId = user.Id;
                }
            }

            if (!staffSeeder.Users.Any(u => u.Email == "IvankaPetrova@expresseagles.com"))
            {
                Employee employee = dbContext.Employees.FirstOrDefault(x => x.PhoneNumber == "00359898331456");

                IdentityResult result = await staffSeeder.CreateAsync(
                    new ApplicationUser
                    {
                        UserName = "IvankaPetrova",
                        Email = "IvankaPetrova@expresseagles.com",
                        PhoneNumber = "00359898331456",
                        PhoneNumberConfirmed = true,
                        EmailConfirmed = true,
                        EmployeeId = employee.Id,
                    },
                    "IP123456##");

                if (result.Succeeded)
                {
                    ApplicationUser user = await staffSeeder.FindByNameAsync("IvankaPetrova");
                    await staffSeeder.AddToRoleAsync(user, GlobalConstants.EmployeeRoleName);
                    employee.ApplicationUserId = user.Id;
                }
            }

            if (!staffSeeder.Users.Any(u => u.Email == "MilenaDimitrova@expresseagles.com"))
            {
                Employee employee = dbContext.Employees.FirstOrDefault(x => x.PhoneNumber == "00359888658974");

                IdentityResult result = await staffSeeder.CreateAsync(
                    new ApplicationUser
                    {
                        UserName = "MilenaDimitrova",
                        Email = "MilenaDimitrova@expresseagles.com",
                        PhoneNumber = "00359888658974",
                        PhoneNumberConfirmed = true,
                        EmailConfirmed = true,
                        EmployeeId = employee.Id,
                    },
                    "MD123456##");

                if (result.Succeeded)
                {
                    ApplicationUser user = await staffSeeder.FindByNameAsync("MilenaDimitrova");
                    await staffSeeder.AddToRoleAsync(user, GlobalConstants.EmployeeRoleName);
                    employee.ApplicationUserId = user.Id;
                }
            }
        }
    }
}
