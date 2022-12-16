namespace ExpressEaglesCourier.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;

    using ExpressEaglesCourier.Data.Common.Repositories;
    using ExpressEaglesCourier.Data.Models;
    using Moq;

    // public class CustomerMockRepository
    // {
    //    public static Mock<IDeletableEntityRepository<Customer>> CustomerMockRepo()
    //    {
    //        Mock<IDeletableEntityRepository<Customer>> customerMockRepo = new Mock<IDeletableEntityRepository<Customer>>();

    // List<Customer> customerList = new List<Customer>()
    //        {
    //            new Customer()
    //            {
    //                Id = "74d8ad86-ef7a-49bf-b435-96f263b0ed2d",
    //                FirstName = "Gosho",
    //                MiddleName = "Goshev",
    //                LastName = "Goshev",
    //                Address = "Lazur block 33",
    //                City = "Bourgas",
    //                Country = "Bulgaria",
    //                CompanyName = string.Empty,
    //                PhoneNumber = "00359889124567",
    //            },
    //            new Customer()
    //            {
    //                Id = "8ac0087e-c216-4d7a-82e9-2b2e6afe5768",
    //                FirstName = "Petar",
    //                MiddleName = "Peshev",
    //                LastName = "Goshev",
    //                Address = "Slaveykov block 35",
    //                City = "Bourgas",
    //                Country = "Bulgaria",
    //                CompanyName = string.Empty,
    //                PhoneNumber = "00359889765431",
    //            },
    //        };

    // customerMockRepo.Setup(r => r.AddAsync(It.IsAny<Customer>()))
    //           .Callback((Customer customer) => customerList.Add(customer));

    // customerMockRepo.Setup(r => r.All())
    //            .Returns(customerList.Where(x => x.IsDeleted = false).AsQueryable());

    // customerMockRepo.Setup(r => r.AllAsNoTrackingWithDeleted()).Returns(customerList.AsQueryable());

    // customerMockRepo.Setup(r => r.AllAsNoTracking())
    //            .Returns(customerList.AsQueryable());

    // customerMockRepo.Setup(r => r.Delete(It.IsAny<Customer>()))
    //            .Callback((Customer customer) => customerList.Remove(customer));

    // return customerMockRepo;
    // }
    // }
}
