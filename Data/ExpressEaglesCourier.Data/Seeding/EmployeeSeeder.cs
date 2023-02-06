namespace ExpressEaglesCourier.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class EmployeeSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (await dbContext.Employees.AnyAsync())
            {
                return;
            }

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
                    PhoneNumber = "00359888121210",
                    DateOfBirth = DateTime.ParseExact("07-02-1998", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    HiredOn = DateTime.ParseExact("02-02-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    Salary = 1200,
                    OfficeId = 1,
                    PositionId = 10,
                },
                new Employee() // customer front desk service
                {
                    FirstName = "Ivanka",
                    MiddleName = "Dimitrova",
                    LastName = "Petrova",
                    Address = "Stefan Stambolov Street, No. 99, floor 2",
                    City = "Bourgas",
                    Country = "Bulgaria",
                    PhoneNumber = "00359898331456",
                    DateOfBirth = DateTime.ParseExact("08-02-2001", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    HiredOn = DateTime.ParseExact("06-06-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    Salary = 1350,
                    OfficeId = 2,
                    PositionId = 3,
                },
                new Employee() // data entry operator
                {
                    FirstName = "Milena",
                    MiddleName = "Stoilova",
                    LastName = "Dimitrova",
                    Address = "Izgrev Quarter, block 58, entr. 3, floor 5, ap. 16",
                    City = "Bourgas",
                    Country = "Bulgaria",
                    PhoneNumber = "00359888658974",
                    DateOfBirth = DateTime.ParseExact("17-09-2002", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    HiredOn = DateTime.ParseExact("06-06-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    Salary = 1300,
                    OfficeId = 1,
                    PositionId = 5,
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
                    PhoneNumber = "00359888656565",
                    DateOfBirth = DateTime.ParseExact("03-10-1998", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    HiredOn = DateTime.ParseExact("08-06-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    Salary = 1200,
                    OfficeId = 3,
                    PositionId = 10,
                },
                new Employee() // customer front desk service
                {
                    FirstName = "Iva",
                    MiddleName = "Ivaylova",
                    LastName = "Stoyanova",
                    Address = "Tsar Boris III Street, No. 19",
                    City = "Varna",
                    Country = "Bulgaria",
                    PhoneNumber = "00359899313131",
                    DateOfBirth = DateTime.ParseExact("20-08-1997", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    HiredOn = DateTime.ParseExact("08-06-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    Salary = 1350,
                    OfficeId = 3,
                    PositionId = 3,
                },
                new Employee() // data entry operator
                {
                    FirstName = "Daniela",
                    MiddleName = "Georgieva",
                    LastName = "Stoilova",
                    Address = "Aleksandar Dyakovich Street No.38",
                    City = "Varna",
                    Country = "Bulgaria",
                    PhoneNumber = "00359888333333",
                    DateOfBirth = DateTime.ParseExact("30-09-2002", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    HiredOn = DateTime.ParseExact("08-06-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    Salary = 1300,
                    OfficeId = 3,
                    PositionId = 5,
                },
            };

            await dbContext.Employees.AddRangeAsync(employees);
        }
    }
}
