namespace ExpressEaglesCourier.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data.Models;

    public class CitySeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            City city1 = new City()
            {
                Name = "Bourgas",
                CityCode = "8000",
                CountryId = dbContext.Countries.FirstOrDefault(x => x.Name == "Bulgaria").Id,
            };

            City city2 = new City()
            {
                Name = "Varna",
                CityCode = "9000",
                CountryId = dbContext.Countries.FirstOrDefault(x => x.Name == "Bulgaria").Id,
            };
            await dbContext.Cities.AddRangeAsync(city1, city2);
        }
    }
}
