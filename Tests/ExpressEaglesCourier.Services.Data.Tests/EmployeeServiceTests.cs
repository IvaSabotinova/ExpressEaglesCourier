namespace ExpressEaglesCourier.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data;
    using ExpressEaglesCourier.Data.Common.Repositories;
    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Data.Repositories;
    using ExpressEaglesCourier.Services.Data.Employees;
    using ExpressEaglesCourier.Web.ViewModels.Employee;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Xunit;

    // public class EmployeeServiceTests
    // {
        // public ApplicationDbContext GetDbContext()
        // {
        //    DbContextOptionsBuilder<ApplicationDbContext> optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
        //        .UseInMemoryDatabase("TestEmployee");
        //    ApplicationDbContext dbContext = new ApplicationDbContext(optionBuilder.Options);
        //    return dbContext;
        // }

        // public EmployeeService GetEmployeeService()
        // {
        //    EfDeletableEntityRepository<Employee> employeeRepo = new EfDeletableEntityRepository<Employee>(this.GetDbContext());

        // EfDeletableEntityRepository<Office> officeRepo = new EfDeletableEntityRepository<Office>(this.GetDbContext());

        // EfDeletableEntityRepository<Position> positionRepo = new EfDeletableEntityRepository<Position>(this.GetDbContext());

        // EfDeletableEntityRepository<Vehicle> vehicleRepo = new EfDeletableEntityRepository<Vehicle>(this.GetDbContext());

        // Mock<UserManager<ApplicationUser>> userManagerMock = new Mock<UserManager<ApplicationUser>>();

        // UserManager<ApplicationUser> userManager = userManagerMock.Object;

        // EmployeeService employeeService = new EmployeeService(employeeRepo, officeRepo, positionRepo, vehicleRepo, userManager);

        // return employeeService;
        // }

        // public EmployeeFormModel GetEmployeeFormModel()
        // {
        //    EmployeeFormModel model = new EmployeeFormModel()
        //    {
        //        Id = "e7b58676-550a-449e-b390-e21fb7e47f94",
        //        FirstName = "Martin",
        //        MiddleName = "Martinov",
        //        LastName = "Martinov",
        //        Address = "Zornitsa block 15",
        //        City = "Bourgas",
        //        Country = "Bulgaria",
        //        HiredOn = DateTime.Now.AddDays(-2),
        //        PhoneNumber = "00359888222222",
        //        OfficeId = 1,
        //        PositionId = 1,
        //        VehicleId = 1,
        //        ResignOn = null,
        //        Salary = 1200,
        //    };

        // return model;
        // }

        // public static Mock<UserManager<ApplicationUser>> MockUserManager()
        //    //where TApplicationUser : class
        //    {
        //        var store = new Mock<IUserStore<ApplicationUser>>();
        //        var mgr = new Mock<UserManager<ApplicationUser>>(store.Object,
        //            null, null, null, null, null, null, null);
        //        mgr.Object.UserValidators.Add(new UserValidator<ApplicationUser>());
        //        mgr.Object.PasswordValidators.Add(new PasswordValidator<ApplicationUser>());

        // mgr.Setup(x => x.DeleteAsync(It.IsAny<ApplicationUser>())).ReturnsAsync(IdentityResult.Success);
        //        //mgr.Setup(x => x.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success).Callback<ApplicationUser, string>((x, y) => userList.Add(x));
        //        mgr.Setup(x => x.UpdateAsync(It.IsAny<ApplicationUser>())).ReturnsAsync(IdentityResult.Success);

        // return mgr;
        //    }

        // [Fact]

        // public async Task GetEmployeeDetailsTest()
        // {
        //    var options = new DbContextOptionsBuilder<ApplicationDbContext>()
        //        .UseInMemoryDatabase(databaseName: "EmployeeDb").Options;
        //    using var dbContext = new ApplicationDbContext(options);
        //    dbContext.Employees.Add(new Employee()
        //    {
        //        Id = "e7b58676-550a-449e-b390-e21fb7e47f94",
        //        FirstName = "Martin",
        //        MiddleName = "Martinov",
        //        LastName = "Martinov",
        //        Address = "Zornitsa block 15",
        //        City = "Bourgas",
        //        Country = "Bulgaria",
        //        HiredOn = DateTime.Now.AddDays(-2),
        //        PhoneNumber = "00359888222222",
        //        OfficeId = 1,
        //        PositionId = 1,
        //        VehicleId = 1,
        //        ResignOn = null,
        //        Salary = 1200,
        //    });

        // await dbContext.SaveChangesAsync();

        // using var repository = new EfDeletableEntityRepository<Employee>(dbContext);

        // EfDeletableEntityRepository<Office> officeRepo = new EfDeletableEntityRepository<Office>(dbContext);

        // EfDeletableEntityRepository<Position> positionRepo = new EfDeletableEntityRepository<Position>(dbContext);

        // EfDeletableEntityRepository<Vehicle> vehicleRepo = new EfDeletableEntityRepository<Vehicle>(dbContext);
        //   var result = MockUserManager();

        // var service = new EmployeeService(repository, officeRepo, positionRepo, vehicleRepo, result.Object);
        //    //Assert.Equal(3, service.GetCount());

        // EmployeeDetailsViewModel model = await service.GetEmployeeDetails(dbContext.Employees.FirstOrDefaultAsync().Result.Id);

        // Assert.Equal("Martin Martinov", model.FullName);
        // }
    // }
}
