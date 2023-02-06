namespace ExpressEaglesCourier.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class PositionSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (await dbContext.Positions.AnyAsync())
            {
                return;
            }

            List<Position> positions = new List<Position>()
            {
             new Position()
            {
                JobTitle = "Manager",
            },
             new Position()
            {
                JobTitle = "Customer Relations Specialist",
            },
             new Position()
            {
                JobTitle = "Customer Front-Desk Service",
            },
             new Position()
            {
                JobTitle = "Human Resources",
            },
             new Position()
            {
                JobTitle = "Data Entry Operator",
            },
             new Position()
            {
                JobTitle = "Office Administrator",
            },
             new Position()
            {
                JobTitle = "Accountant",
            },

             new Position()
            {
                JobTitle = "Warehouse Supervisor",
            },
             new Position()
            {
                JobTitle = "Warehouse sorter",
            },
             new Position()
            {
                JobTitle = "Driver courier",
            },
             new Position()
            {
                JobTitle = "Office Cleaner",
            },
            };
            await dbContext.Positions.AddRangeAsync(positions);
        }
    }
}
