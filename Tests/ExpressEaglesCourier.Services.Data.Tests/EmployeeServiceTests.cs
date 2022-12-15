namespace ExpressEaglesCourier.Services.Data.Tests
{
    //public class EmployeeServiceTests
    //{
    //    public ApplicationDbContext GetDbContext()
    //    {
    //        DbContextOptionsBuilder<ApplicationDbContext> optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
    //            .UseInMemoryDatabase("TestEmployee");
    //        ApplicationDbContext dbContext = new ApplicationDbContext(optionBuilder.Options);
    //        return dbContext;
    //    }

    //    public EmployeeService GetEmployeeService()
    //    {
    //        EfDeletableEntityRepository<Employee> employeeRepo = new EfDeletableEntityRepository<Employee>(this.GetDbContext());

    //        EfDeletableEntityRepository<Office> officeRepo = new EfDeletableEntityRepository<Office>(this.GetDbContext());

    //        EfDeletableEntityRepository<Position> positionRepo = new EfDeletableEntityRepository<Position>(this.GetDbContext());

    //        EfDeletableEntityRepository<Vehicle> vehicleRepo = new EfDeletableEntityRepository<Vehicle>(this.GetDbContext());

    //        Mock<UserManager<ApplicationUser>> userManagerMock = new Mock<UserManager<ApplicationUser>>();

    //        UserManager<ApplicationUser> userManager = userManagerMock.Object;

    //        EmployeeService employeeService = new EmployeeService(employeeRepo, officeRepo, positionRepo, vehicleRepo, userManager);

    //        return employeeService;
    //    }

    //    public EmployeeFormModel GetEmployeeFormModel()
    //    {
    //        EmployeeFormModel model = new EmployeeFormModel()
    //        {
    //            Id = "e7b58676-550a-449e-b390-e21fb7e47f94",
    //            FirstName = "Martin",
    //            MiddleName = "Martinov",
    //            LastName = "Martinov",
    //            Address = "Zornitsa block 15",
    //            City = "Bourgas",
    //            Country = "Bulgaria",
    //            HiredOn = DateTime.Now.AddDays(-2),
    //            PhoneNumber = "00359888222222",
    //            OfficeId = 1,
    //            PositionId = 1,
    //            VehicleId = 1,
    //            ResignOn = null,
    //            Salary = 1200,
    //        };

    //        return model;
    //    }

    //    [Fact]

    //    public async Task GetEmployeeDetailsTest()
    //    {
    //        this.GetDbContext().Employees.Add(new Employee()
    //        {
    //            Id = "e7b58676-550a-449e-b390-e21fb7e47f94",
    //            FirstName = "Martin",
    //            MiddleName = "Martinov",
    //            LastName = "Martinov",
    //            Address = "Zornitsa block 15",
    //            City = "Bourgas",
    //            Country = "Bulgaria",
    //            HiredOn = DateTime.Now.AddDays(-2),
    //            PhoneNumber = "00359888222222",
    //            OfficeId = 1,
    //            PositionId = 1,
    //            VehicleId = 1,
    //            ResignOn = null,
    //            Salary = 1200,
    //        });

    //        EmployeeDetailsViewModel model = await this.GetEmployeeService().GetEmployeeDetails("e7b58676-550a-449e-b390-e21fb7e47f94");

    //        Assert.NotNull(model);
    //    }
    //}
}
