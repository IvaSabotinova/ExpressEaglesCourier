namespace ExpressEaglesCourier.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data.Models;

    public class CountrySeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            Country country1 = new Country()
            {
                Name = "Bulgaria",
                CountryCode = "BG",
            };

            await dbContext.Countries.AddAsync(country1);
        }
    }
}
