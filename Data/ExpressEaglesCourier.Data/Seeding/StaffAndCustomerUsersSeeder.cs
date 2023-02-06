namespace ExpressEaglesCourier.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Common;
    using ExpressEaglesCourier.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    public class StaffAndCustomerUsersSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            UserManager<ApplicationUser> userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            if (userManager.Users.Count() > 1)
            {
                return;
            }

            if (!userManager.Users.Any(u => u.Email == "IvaStoyanova@expresseagles.com"))
            {
                Employee employee = dbContext.Employees.FirstOrDefault(x => x.PhoneNumber == "00359899313131");

                IdentityResult result = await userManager.CreateAsync(
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
                    ApplicationUser user = await userManager.FindByNameAsync("IvaStoyanova");
                    await userManager.AddToRoleAsync(user, GlobalConstants.EmployeeRoleName);
                    employee.ApplicationUserId = user.Id;
                }
            }

            if (!userManager.Users.Any(u => u.Email == "DanielaStoilova@expresseagles.com"))
            {
                Employee employee = dbContext.Employees.FirstOrDefault(x => x.PhoneNumber == "00359888333333");

                IdentityResult result = await userManager.CreateAsync(
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
                    ApplicationUser user = await userManager.FindByNameAsync("DanielaStoilova");
                    await userManager.AddToRoleAsync(user, GlobalConstants.EmployeeRoleName);
                    employee.ApplicationUserId = user.Id;
                }
            }

            if (!userManager.Users.Any(u => u.Email == "IvankaPetrova@expresseagles.com"))
            {
                Employee employee = dbContext.Employees.FirstOrDefault(x => x.PhoneNumber == "00359898331456");

                IdentityResult result = await userManager.CreateAsync(
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
                    ApplicationUser user = await userManager.FindByNameAsync("IvankaPetrova");
                    await userManager.AddToRoleAsync(user, GlobalConstants.EmployeeRoleName);
                    employee.ApplicationUserId = user.Id;
                }
            }

            if (!userManager.Users.Any(u => u.Email == "MilenaDimitrova@expresseagles.com"))
            {
                Employee employee = dbContext.Employees.FirstOrDefault(x => x.PhoneNumber == "00359888658974");

                IdentityResult result = await userManager.CreateAsync(
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
                    ApplicationUser user = await userManager.FindByNameAsync("MilenaDimitrova");
                    await userManager.AddToRoleAsync(user, GlobalConstants.EmployeeRoleName);
                    employee.ApplicationUserId = user.Id;
                }
            }

            if (!userManager.Users.Any(u => u.Email == "zdravko@abv.bg"))
            {
                Customer customer = dbContext.Customers.FirstOrDefault(x => x.PhoneNumber == "00359877334334");

                IdentityResult result = await userManager.CreateAsync(
                    new ApplicationUser
                    {
                        UserName = "ZdravkoAtan",
                        Email = "zdravko@abv.bg",
                        PhoneNumber = "00359877334334",
                        PhoneNumberConfirmed = true,
                        EmailConfirmed = true,
                        CustomerId = customer.Id,
                    },
                    "ZA123456##");

                if (result.Succeeded)
                {
                    ApplicationUser user = await userManager.FindByNameAsync("ZdravkoAtan");
                    await userManager.AddToRoleAsync(user, GlobalConstants.CustomerUserRoleName);
                    customer.ApplicationUserId = user.Id;
                }
            }

            if (!userManager.Users.Any(u => u.Email == "denislav@abv.bg"))
            {
                Customer customer = dbContext.Customers.FirstOrDefault(x => x.PhoneNumber == "00359888556556");

                IdentityResult result = await userManager.CreateAsync(
                    new ApplicationUser
                    {
                        UserName = "Denislav2001",
                        Email = "denislav@abv.bg",
                        PhoneNumber = "00359888556556",
                        PhoneNumberConfirmed = true,
                        EmailConfirmed = true,
                        CustomerId = customer.Id,
                    },
                    "DK123456##");

                if (result.Succeeded)
                {
                    ApplicationUser user = await userManager.FindByNameAsync("Denislav2001");
                    await userManager.AddToRoleAsync(user, GlobalConstants.CustomerUserRoleName);
                    customer.ApplicationUserId = user.Id;
                }
            }

            if (!userManager.Users.Any(u => u.Email == "yasen@abv.bg"))
            {
                Customer customer = dbContext.Customers.FirstOrDefault(x => x.PhoneNumber == "00359877222222");

                IdentityResult result = await userManager.CreateAsync(
                    new ApplicationUser
                    {
                        UserName = "Yasen2001",
                        Email = "yasen@abv.bg",
                        PhoneNumber = "00359877222222",
                        PhoneNumberConfirmed = true,
                        EmailConfirmed = true,
                        CustomerId = customer.Id,
                    },
                    "YY123456##");

                if (result.Succeeded)
                {
                    ApplicationUser user = await userManager.FindByNameAsync("Yasen2001");
                    await userManager.AddToRoleAsync(user, GlobalConstants.CustomerUserRoleName);
                    customer.ApplicationUserId = user.Id;
                }
            }

            if (!userManager.Users.Any(u => u.Email == "rayko@abv.bg"))
            {
                Customer customer = dbContext.Customers.FirstOrDefault(x => x.PhoneNumber == "00359877111111");

                IdentityResult result = await userManager.CreateAsync(
                    new ApplicationUser
                    {
                        UserName = "Rayko2001",
                        Email = "rayko@abv.bg",
                        PhoneNumber = "00359877111111",
                        PhoneNumberConfirmed = true,
                        EmailConfirmed = true,
                        CustomerId = customer.Id,
                    },
                    "RS123456##");

                if (result.Succeeded)
                {
                    ApplicationUser user = await userManager.FindByNameAsync("Rayko2001");
                    await userManager.AddToRoleAsync(user, GlobalConstants.CustomerUserRoleName);
                    customer.ApplicationUserId = user.Id;
                }
            }

            if (!userManager.Users.Any(u => u.Email == "nikola@abv.bg"))
            {
                Customer customer = dbContext.Customers.FirstOrDefault(x => x.PhoneNumber == "00359898554554");

                IdentityResult result = await userManager.CreateAsync(
                    new ApplicationUser
                    {
                        UserName = "Nikola2001",
                        Email = "nikola@abv.bg",
                        PhoneNumber = "00359898554554",
                        PhoneNumberConfirmed = true,
                        EmailConfirmed = true,
                        CustomerId = customer.Id,
                    },
                    "NA123456##");

                if (result.Succeeded)
                {
                    ApplicationUser user = await userManager.FindByNameAsync("Nikola2001");
                    await userManager.AddToRoleAsync(user, GlobalConstants.CustomerUserRoleName);
                    customer.ApplicationUserId = user.Id;
                }
            }

            if (!userManager.Users.Any(u => u.Email == "simona@abv.bg"))
            {
                Customer customer = dbContext.Customers.FirstOrDefault(x => x.PhoneNumber == "00359899555555");

                IdentityResult result = await userManager.CreateAsync(
                    new ApplicationUser
                    {
                        UserName = "Simona2001",
                        Email = "simona@abv.bg",
                        PhoneNumber = "00359899555555",
                        PhoneNumberConfirmed = true,
                        EmailConfirmed = true,
                        CustomerId = customer.Id,
                    },
                    "SS123456##");

                if (result.Succeeded)
                {
                    ApplicationUser user = await userManager.FindByNameAsync("Simona2001");
                    await userManager.AddToRoleAsync(user, GlobalConstants.CustomerUserRoleName);
                    customer.ApplicationUserId = user.Id;
                }
            }
        }
    }
}
