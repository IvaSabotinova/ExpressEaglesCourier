namespace ExpressEaglesCourier.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data.Models;

    public class CustomerSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            Customer customer1 = new Customer()
            {
                FirstName = "Yasen",
                MiddleName = "Vladislavov",
                LastName = "Yavorov",
                Address = "Vasil Levski Street 42, floor 1",
                City = "Bourgas",
                Country = "Bulgaria",
                PhoneNumber = "00359877222222",
            };
            Customer customer2 = new Customer()
            {
                FirstName = "Rayko",
                MiddleName = "Rumeonov",
                LastName = "Samuilov",
                Address = "Macedonia Street No. 21",
                City = "Bourgas",
                Country = "Bulgaria",
                PhoneNumber = "00359877111111",
            };
            Customer customer3 = new Customer()
            {
                FirstName = "Zdravko",
                MiddleName = "Asenov",
                LastName = "Atanasov",
                Address = "Vasil Levski Street 12, floor 1",
                City = "Bourgas",
                Country = "Bulgaria",
                PhoneNumber = "00359877334334",
            };
            Customer customer4 = new Customer()
            {
                FirstName = "Denislav",
                MiddleName = "Kostadinov",
                LastName = "Karaivanov",
                Address = "Hristo Smirnenski Street 5",
                City = "Varna",
                Country = "Bulgaria",
                PhoneNumber = "00359888556556",
            };
            Customer customer5 = new Customer()
            {
                FirstName = "Simona",
                MiddleName = "Stoyanova",
                LastName = "Stoyanova",
                Address = "Nikola Kozlev Street No. 2",
                City = "Varna",
                Country = "Bulgaria",
                PhoneNumber = "00359899555555",
            };
            Customer customer6 = new Customer()
            {
                FirstName = "Nikola",
                MiddleName = "Atanasov",
                LastName = "Atanasov",
                Address = "Bozhur Street No. 3",
                City = "Varna",
                Country = "Bulgaria",
                PhoneNumber = "00359898554554",
            };
            await dbContext.Customers.AddRangeAsync(customer1, customer2, customer3, customer4, customer5, customer6);
        }
    }
}
