namespace ExpressEaglesCourier.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data;
    using ExpressEaglesCourier.Data.Common.Repositories;
    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Data.Repositories;
    using ExpressEaglesCourier.Services.Data.Employees;
    using ExpressEaglesCourier.Services.Mapping;
    using ExpressEaglesCourier.Web.ViewModels.Employees;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using MockQueryable.Moq;
    using Moq;
    using Xunit;

    public class EmployeeServiceTests
    {
        private Mock<UserManager<ApplicationUser>> mockUserManager;

        public ApplicationDbContext GetDbContext()
        {
            DbContextOptionsBuilder<ApplicationDbContext> optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("TestEmployee");
            ApplicationDbContext dbContext = new ApplicationDbContext(optionBuilder.Options);
            return dbContext;
        }

        public EmployeeService GetEmployeeService()
        {
            EfDeletableEntityRepository<Employee> employeeRepo = new EfDeletableEntityRepository<Employee>(this.GetDbContext());

            EfDeletableEntityRepository<Office> officeRepo = new EfDeletableEntityRepository<Office>(this.GetDbContext());

            EfDeletableEntityRepository<Position> positionRepo = new EfDeletableEntityRepository<Position>(this.GetDbContext());

            EfDeletableEntityRepository<Vehicle> vehicleRepo = new EfDeletableEntityRepository<Vehicle>(this.GetDbContext());

            this.mockUserManager = new Mock<UserManager<ApplicationUser>>(
                Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null);

            EmployeeService employeeService = new EmployeeService(employeeRepo, officeRepo, positionRepo, vehicleRepo, this.mockUserManager.Object);

            return employeeService;
        }

        public EmployeeFormModel GetEmployeeFormModel()
        {
            EmployeeFormModel model = new EmployeeFormModel()
            {
                FirstName = "Martin",
                MiddleName = "Martinov",
                LastName = "Martinov",
                Address = "Zornitsa block 15",
                City = "Bourgas",
                Country = "Bulgaria",
                HiredOn = DateTime.Now.AddDays(-2),
                PhoneNumber = "00359888999999",
                OfficeId = 1,
                PositionId = 8,
                VehicleId = null,
                ResignOn = null,
                Salary = 1200,
            };

            return model;
        }

        [Fact]

        public async Task CreateEmployeeAsyncTest()
        {
            await this.GetEmployeeService().CreateEmployeeAsync(this.GetEmployeeFormModel());

            Employee employee = await this.GetDbContext().Employees
                .Where(x => x.PhoneNumber == "00359888999999").FirstOrDefaultAsync();

            Assert.Equal(this.GetEmployeeFormModel().PhoneNumber, employee.PhoneNumber);
        }

        [Fact]

        public async Task AddRolesToEmployeesTest()
        {
            Mock<IDeletableEntityRepository<Employee>> employeeMockRepo = new Mock<IDeletableEntityRepository<Employee>>();

            Mock<IDeletableEntityRepository<Office>> officeMockRepo = new Mock<IDeletableEntityRepository<Office>>();

            Mock<IDeletableEntityRepository<Position>> positionMockRepo = new Mock<IDeletableEntityRepository<Position>>();

            Mock<IDeletableEntityRepository<Vehicle>> vehicleMockRepo = new Mock<IDeletableEntityRepository<Vehicle>>();

            Mock<UserManager<ApplicationUser>> mockUserManager = new Mock<UserManager<ApplicationUser>>(
               Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null);

            EmployeeService employeeService = new EmployeeService(
                employeeMockRepo.Object,
                officeMockRepo.Object,
                positionMockRepo.Object,
                vehicleMockRepo.Object,
                mockUserManager.Object);

            Employee employee = new Employee()
            {
                Id = "c087ed3a-10eb-47ff-bc38-65682f7d1dd4",
                FirstName = "Martin",
                MiddleName = "Goshev",
                LastName = "Goshev",
                Address = "Slaveykov block 33",
                City = "Bourgas",
                Country = "Bulgaria",
                HiredOn = DateTime.Now.AddDays(-2),
                PhoneNumber = "00333111111111",
                PositionId = 1,
                OfficeId = 2,
                VehicleId = null,
                ResignOn = null,
                Salary = 1200,
            };

            mockUserManager.Setup(x => x.CreateAsync(It.IsAny<ApplicationUser>())).ReturnsAsync(IdentityResult.Success);

            mockUserManager.Setup(x => x.AddToRoleAsync(
                It.IsAny<ApplicationUser>(),
                It.IsAny<string>()))
                .ReturnsAsync((ApplicationUser user, string role) =>
                {
                    user.Employee = new Employee()
                    {
                        PositionId = 1,
                    };
                    role = "Manager";
                    return IdentityResult.Success;
                });

            mockUserManager.Setup(x => x.IsInRoleAsync(
                It.IsAny<ApplicationUser>(),
                It.IsAny<string>()))
                .ReturnsAsync((ApplicationUser user, string role) =>
                {
                    user.Employee = new Employee()
                    {
                        PositionId = 1,
                    };
                    role = "Manager";
                    return true;
                });

            await employeeService.AddRolesToEmployees(employee);

            Assert.NotNull(employee.ApplicationUser);

            Assert.True(await mockUserManager.Object.IsInRoleAsync(employee.ApplicationUser, "Manager"));
        }

        // [Fact]
        // public async Task GetEmployeeDetailsTest()
        // {
        //    Mock<IDeletableEntityRepository<Employee>> employeeMockRepo = new Mock<IDeletableEntityRepository<Employee>>();

        // Mock<IDeletableEntityRepository<Office>> officeMockRepo = new Mock<IDeletableEntityRepository<Office>>();

        // Mock<IDeletableEntityRepository<Position>> positionMockRepo = new Mock<IDeletableEntityRepository<Position>>();

        // Mock<IDeletableEntityRepository<Vehicle>> vehicleMockRepo = new Mock<IDeletableEntityRepository<Vehicle>>();

        // Mock<UserManager<ApplicationUser>> mockUserManager = new Mock<UserManager<ApplicationUser>>(
        //             Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null);
        //    List<Employee> employeesList = new List<Employee>()
        //    {
        //        new Employee()
        //        {
        //            Id = "14a5cf87-ca5c-48b9-a84d-d72ceae42c18",
        //            FirstName = "Gosho",
        //            MiddleName = "Goshev",
        //            LastName = "Goshev",
        //            Address = "Lazur block 33",
        //            City = "Bourgas",
        //            Country = "Bulgaria",
        //            DateOfBirth = DateTime.Now.Date.AddYears(-21),
        //            HiredOn = DateTime.Now.AddDays(-2),
        //            PhoneNumber = "00359111111111",
        //            VehicleId = null,
        //            ResignOn = null,
        //            Salary = 1200,
        //            Position = new Position()
        //            {
        //                JobTitle = "Manager",
        //            },
        //            Office = new Office()
        //            {
        //                Address = "Izgrev block 55",
        //                City = new City()
        //                {
        //                    Name = "Bourgas",
        //                    Country = new Country()
        //                    {
        //                    Name = "Bulgaria",
        //                    },
        //                },
        //            },
        //        },
        //    };

        // employeeMockRepo.Setup(x => x.AllAsNoTracking())
        //              .Returns(employeesList.AsQueryable().BuildMock());

        // //AutoMapperConfig.RegisterMappings(typeof(EmployeeDetailsViewModel).Assembly);
        //    AutoMapperConfig.RegisterMappings(Assembly.Load("ExpressEaglesCourier.Web.ViewModels"));

        // EmployeeService employeeService = new EmployeeService(
        //              employeeMockRepo.Object,
        //              officeMockRepo.Object,
        //              positionMockRepo.Object,
        //              vehicleMockRepo.Object,
        //              mockUserManager.Object);

        // EmployeeDetailsViewModel model = await employeeService.GetEmployeeDetailsById<EmployeeDetailsViewModel>("14a5cf87-ca5c-48b9-a84d-d72ceae42c18");

        // Assert.Equal("Gosho Goshev Goshev", model.FullName);
        //    Assert.Equal("Izgrev block 55, Bourgas, Bulgaria", model.OfficeDetails);
        // }
        [Fact]
        public async Task GetEmployeeByIdTest()
        {
            await this.GetEmployeeService().CreateEmployeeAsync(this.GetEmployeeFormModel());

            Employee employeeDb = await this.GetDbContext().Employees.FirstOrDefaultAsync();

            Employee employee = await this.GetEmployeeService().GetEmployeeById(employeeDb.Id);

            Assert.Equal(employeeDb.Id, employee.Id);
        }

        [Fact]

        public async Task GetEmployeeForEditAsyncTest()
        {
            await this.GetEmployeeService().CreateEmployeeAsync(this.GetEmployeeFormModel());

            Employee employee = await this.GetDbContext().Employees
                .Where(x => x.PhoneNumber == "00359888999999").FirstOrDefaultAsync();

            AutoMapperConfig.RegisterMappings(Assembly.Load("ExpressEaglesCourier.Web.ViewModels"));

            EmployeeFormModel model = await this.GetEmployeeService()
            .GetEmployeeDetailsById<EmployeeFormModel>(employee.Id);

            Assert.Equal(employee.FirstName, model.FirstName);
            Assert.Equal(employee.Country, model.Country);
        }

        [Fact]

        public async Task EditEmployeeAsync()
        {
            EmployeeFormModel inputModel = new EmployeeFormModel()
            {
                FirstName = "Haralambi",
                MiddleName = "Haralambov",
                LastName = "Haralbamov",
                Address = "Slaveikov block 15",
                City = "Bourgas",
                Country = "Bulgaria",
                PhoneNumber = "00111111111111",
                HiredOn = DateTime.Now.AddDays(-2),
                Salary = 1200,
                OfficeId = 1,
                PositionId = 8,
                ResignOn = null,
                VehicleId = null,
            };

            await this.GetEmployeeService().CreateEmployeeAsync(inputModel);

            Employee employeeDb = await this.GetDbContext().Employees
                .Where(x => x.PhoneNumber == "00111111111111").FirstOrDefaultAsync();

            AutoMapperConfig.RegisterMappings(Assembly.Load("ExpressEaglesCourier.Web.ViewModels"));

            EmployeeFormModel model = await this.GetEmployeeService().GetEmployeeDetailsById<EmployeeFormModel>(employeeDb.Id);

            await this.GetEmployeeService().EditEmployeeAsync(new EmployeeFormModel()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = "Goshev",
                Address = model.Address,
                City = model.City,
                Country = model.Country,
                PhoneNumber = model.PhoneNumber,
                HiredOn = model.HiredOn,
                Salary = model.Salary,
                OfficeId = model.OfficeId,
                PositionId = model.PositionId,
                ResignOn = model.ResignOn,
                VehicleId = model.VehicleId,
            });

            Employee employeeNew = await this.GetDbContext().Employees.LastOrDefaultAsync();

            Assert.Equal("Goshev", employeeNew.LastName);
        }

        [Fact]

        public async Task EditEmployeeAsyncExceptionTest()
        {
            Employee employee = await this.GetDbContext().Employees.Where(x => x.FirstName == "Boci").FirstOrDefaultAsync();

            AutoMapperConfig.RegisterMappings(Assembly.Load("ExpressEaglesCourier.Web.ViewModels"));

            await Assert.ThrowsAsync<NullReferenceException>(() =>
            this.GetEmployeeService().GetEmployeeDetailsById<EmployeeFormModel>(employee.Id));
        }

        [Fact]

        public async Task DeleteEmployeeAsyncTest()
        {
            EmployeeFormModel inputModel = new EmployeeFormModel()
            {
                FirstName = "Ivo",
                MiddleName = "Ivov",
                LastName = "Ivov",
                Address = "Zornitsa block 15",
                City = "Bourgas",
                Country = "Bulgaria",
                PhoneNumber = "00222222222222",
                HiredOn = DateTime.Now.AddDays(-2),
                Salary = 1200,
                OfficeId = 2,
                PositionId = 8,
                ResignOn = null,
                VehicleId = null,
            };

            await this.GetEmployeeService().CreateEmployeeAsync(inputModel);

            Employee employeeDb = await this.GetDbContext().Employees
                .Where(x => x.PhoneNumber == "00222222222222")
                .FirstOrDefaultAsync();

            await this.GetEmployeeService().DeleteEmployeeAsync(employeeDb.Id);

            Assert.False(await this.GetDbContext().Employees
                .AnyAsync(x => x.Id == employeeDb.Id));
        }

        [Fact]
        public async Task DeleteEmployeeAsyncExceptionTest()
        {
            await Assert.ThrowsAsync<NullReferenceException>(() =>
             this.GetEmployeeService().DeleteEmployeeAsync("e0b758b0-2f5e-4f9c-bc49-a1e03a26065e"));
        }
    }
}
