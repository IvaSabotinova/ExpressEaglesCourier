namespace ExpressEaglesCourier.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data.Models;

    public class EmployeeSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            List<Employee> employees = new List<Employee>()
            {
                // Bourgas
                new Employee() // driver courier
                {
                    FirstName = "Petar",
                    MiddleName = "Ivanov",
                    LastName = "Kostadinov",
                    Address = "Topolica Street, bl. 22, entr. 1, floor 2",
                    City = "Bourgas",
                    Country = "Bulgaria",
                    PhoneNumber = "00359 888 121210",
                    HiredOn = DateTime.ParseExact("02-02-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    Salary = 1200,
                    OfficeId = "70d49f24-f37f-41d1-b017-96f12c2f3821",
                    PositionId = "315a7888-8e02-4e70-8aa9-32b1e257643d",
                },
                new Employee() // customer front desk service
                {
                    FirstName = "Ivanka",
                    MiddleName = "Dimitrova",
                    LastName = "Petrova",
                    Address = "Stefan Stambolov Street, No. 99, floor 2",
                    City = "Bourgas",
                    Country = "Bulgaria",
                    PhoneNumber = "00359 898 331456",
                    HiredOn = DateTime.ParseExact("06-06-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    Salary = 1350,
                    OfficeId = "70d49f24-f37f-41d1-b017-96f12c2f3821",
                    PositionId = "a5379d11-01be-4f6c-995a-7efcdac340dc",
                },
                new Employee() // data entry operator
                {
                    FirstName = "Milena",
                    MiddleName = "Stoilova",
                    LastName = "Dimitrova",
                    Address = "Izgrev Quarter, block 58, entr. 3, floor 5, ap. 16",
                    City = "Bourgas",
                    Country = "Bulgaria",
                    PhoneNumber = "00359 888 658974",
                    HiredOn = DateTime.ParseExact("06-06-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    Salary = 1300,
                    OfficeId = "061b9367-aa25-4a41-98b6-81d7eb6cb71e",
                    PositionId = "a156ebfd-02d5-416c-b430-73520065f509",
                },

                // Varna
                new Employee() // driver courier
                {
                    FirstName = "Vasil",
                    MiddleName = "Danailov",
                    LastName = "Petrov",
                    Address = "Vladislav Varnenchik Blvd No.133",
                    City = "Varna",
                    Country = "Bulgaria",
                    PhoneNumber = "00359 888 656565",
                    HiredOn = DateTime.ParseExact("08-06-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    Salary = 1200,
                    OfficeId = "05f0b246-02f7-4e49-a21e-41723df5ed35",
                    PositionId = "315a7888-8e02-4e70-8aa9-32b1e257643d",
                },
                new Employee() // customer front desk service
                {
                    FirstName = "Iva",
                    MiddleName = "Ivaylova",
                    LastName = "Stoyanova",
                    Address = "Tsar Boris III Street, No. 19",
                    City = "Varna",
                    Country = "Bulgaria",
                    PhoneNumber = "00359 899 313131",
                    HiredOn = DateTime.ParseExact("08-06-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    Salary = 1350,
                    OfficeId = "05f0b246-02f7-4e49-a21e-41723df5ed35",
                    PositionId = "a5379d11-01be-4f6c-995a-7efcdac340dc",
                },
                new Employee() // data entry operator
                {
                    FirstName = "Daniela",
                    MiddleName = "Georgieva",
                    LastName = "Stoilova",
                    Address = "Aleksandar Dyakovich Street No.38",
                    City = "Varna",
                    Country = "Bulgaria",
                    PhoneNumber = "00359 888 333333",
                    HiredOn = DateTime.ParseExact("08-06-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    Salary = 1300,
                    OfficeId = "05f0b246-02f7-4e49-a21e-41723df5ed35",
                    PositionId = "a156ebfd-02d5-416c-b430-73520065f509",
                },
            };

            await dbContext.Employees.AddRangeAsync(employees);
        }
    }
}
