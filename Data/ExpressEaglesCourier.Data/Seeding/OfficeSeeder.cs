namespace ExpressEaglesCourier.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class OfficeSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (await dbContext.Offices.AnyAsync())
            {
                return;
            }

            Office office1Bs = new Office()
            {
                Address = "Izgrev Quarter, block 94, floor 1",
                PhoneNumber = "00359 56 122112",
                FaxNumber = "00359 56 122113",
                Email = "expressEaglesBourgas@gmail.com",
                CityId = 1,
            };

            Office office2Bs = new Office()
            {
                Address = "Slaveykov Quarter, block 113, floor 1",
                PhoneNumber = "00359 56 122114",
                FaxNumber = "00359 56 122115",
                Email = "expressEaglesBourgas@gmail.com",
                CityId = 1,
            };

            Office office1Vn = new Office()
            {
                Address = "Vladislav Varnenchik block 33, floor 1",
                PhoneNumber = "00359 52 122116",
                FaxNumber = "00359 52 122117",
                Email = "expressEaglesVarna@gmail.com",
                CityId = 2,
            };
            await dbContext.Offices.AddRangeAsync(office1Bs, office2Bs, office1Vn);
        }
    }
}
