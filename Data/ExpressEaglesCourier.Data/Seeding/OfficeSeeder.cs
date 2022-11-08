namespace ExpressEaglesCourier.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data.Models;

    public class OfficeSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            Office office1Bs = new Office()
            {
                Address = "Izgrev Quarter, block 94, floor 1",
                PhoneNumber = "00359 56 122112",
                FaxNumber = "00359 56 122113",
                Email = "expressEaglesBourgas@gmail.com",
                CityId = dbContext.Cities.FirstOrDefault(x => x.Name == "Bourgas").Id,
            };

            Office office2Bs = new Office()
            {
                Address = "Slaveykov Quarter, block 113, floor 1",
                PhoneNumber = "00359 56 122114",
                FaxNumber = "00359 56 122115",
                Email = "expressEaglesBourgas@gmail.com",
                CityId = office1Bs.CityId,
            };

            Office office1Vn = new Office()
            {
                Address = "Vladislav Varnenchik block 33, floor 1",
                PhoneNumber = "00359 52 122116",
                FaxNumber = "00359 52 122117",
                Email = "expressEaglesVarna@gmail.com",
                CityId = dbContext.Cities.FirstOrDefault(x => x.Name == "Varna").Id,
            };
            await dbContext.Offices.AddRangeAsync(office1Bs, office2Bs, office1Vn);
        }
    }
}
