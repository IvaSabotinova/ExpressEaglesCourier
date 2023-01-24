namespace ExpressEaglesCourier.Services.Data.Searches
{
    using ExpressEaglesCourier.Data.Common.Repositories;
    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Data.Models.Enums;
    using ExpressEaglesCourier.Services.Data.Customers;
    using ExpressEaglesCourier.Services.Data.Employees;
    using ExpressEaglesCourier.Services.Data.Shipments;
    using ExpressEaglesCourier.Services.Data.ShipmentTrackingPaths;
    using ExpressEaglesCourier.Services.Mapping;
    using ExpressEaglesCourier.Web.ViewModels.ShipmentTrackingPaths;
    using ExpressEaglesCourier.Web.ViewModels.ViewComponents.PagingSearchShipment;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class SearchService : ISearchService
    {
        private readonly IDeletableEntityRepository<ShipmentTrackingPath> shipmentTrackingPathRepo;
        private readonly IShipmentTrackingPathService shipmentTrackingPathService;
        private readonly IDeletableEntityRepository<Shipment> shipmentRepo;
        private readonly IShipmentService shipmentService;
        private readonly IDeletableEntityRepository<Employee> employeeRepo;
        private readonly IEmployeeService employeeService;
        private readonly IDeletableEntityRepository<Customer> customerRepo;
        private readonly ICustomerService customerService;

        public SearchService(
            IDeletableEntityRepository<ShipmentTrackingPath> shipmentTrackingPathRepo,
            IShipmentTrackingPathService shipmentTrackingPathService,
            IDeletableEntityRepository<Shipment> shipmentRepo,
            IShipmentService shipmentService,
            IDeletableEntityRepository<Employee> employeeRepo,
            IEmployeeService employeeService,
            IDeletableEntityRepository<Customer> customerRepo,
            ICustomerService customerService)
        {
            this.shipmentTrackingPathRepo = shipmentTrackingPathRepo;
            this.shipmentTrackingPathService = shipmentTrackingPathService;
            this.shipmentRepo = shipmentRepo;
            this.shipmentService = shipmentService;
            this.employeeRepo = employeeRepo;
            this.employeeService = employeeService;
            this.customerRepo = customerRepo;
            this.customerService = customerService;
        }

        public async Task<ShipmentTrackingPathDetailsModel> SearchTrackingPathAsync(string trackingNumber = null)
        {
            ShipmentTrackingPath trackingPath = await this.shipmentTrackingPathRepo.AllAsNoTracking()
                   .FirstOrDefaultAsync(x => x.TrackingNumber == trackingNumber);

            if (trackingPath != null)
            {
                ShipmentTrackingPathDetailsModel model = await
                    this.shipmentTrackingPathService.GetDetailsByTrackingPathId(trackingPath.Id);

                return model;
            }

            return null;
        }

        public async Task<T> SearchShipmentByTrackingNumberAsync<T>(string trackingNumber)
        {
           Shipment shipment = await this.shipmentRepo.AllAsNoTracking()
                .FirstOrDefaultAsync(x => x.TrackingNumber == trackingNumber);

           if (shipment != null)
            {
                T model = await this.shipmentService.GetShipmentDetailsById<T>(shipment.Id);
                return model;
            }

           return default;
        }

        public async Task<T> SearchEmployeeByPhoneNumberAsync<T>(string phoneNumber)
        {
            Employee employee = null;
            if (!string.IsNullOrWhiteSpace(phoneNumber))
            {
                phoneNumber = phoneNumber.Replace(" ", string.Empty);

                if (phoneNumber.Length == 9)
                {
                    employee = await this.employeeRepo.AllAsNoTracking()
                   .FirstOrDefaultAsync(x => x.PhoneNumber.Substring(x.PhoneNumber.Length - 9) == phoneNumber);
                }
                else if (phoneNumber.Length >= 10 && phoneNumber[^10] == '0')
                {
                    employee = await this.employeeRepo.AllAsNoTracking()
                   .FirstOrDefaultAsync(x => x.PhoneNumber.Substring(x.PhoneNumber.Length - 9) == phoneNumber.Substring(phoneNumber.Length - 9));
                }
                else if (phoneNumber.Length >= 10 && phoneNumber[^10] != '0')
                {
                    employee = await this.employeeRepo.AllAsNoTracking()
                   .FirstOrDefaultAsync(x => x.PhoneNumber.Substring(x.PhoneNumber.Length - 10) == phoneNumber.Substring(phoneNumber.Length - 10));
                }
            }

            if (employee != null)
            {
                T model = await this.employeeService.GetEmployeeDetailsById<T>(employee.Id);
                return model;
            }

            return default;
        }

        public async Task<T> SearchCustomerByPhoneNumberAsync<T>(string phoneNumber)
        {
            Customer customer = null;
            if (!string.IsNullOrWhiteSpace(phoneNumber))
            {
                phoneNumber = phoneNumber.Replace(" ", string.Empty);
                if (phoneNumber.Length == 9)
                {
                    customer = await this.customerRepo.AllAsNoTracking()
                   .FirstOrDefaultAsync(x => x.PhoneNumber.Substring(x.PhoneNumber.Length - 9) == phoneNumber);
                }
                else if (phoneNumber.Length >= 10 && phoneNumber[^10] == '0')
                {
                    customer = await this.customerRepo.AllAsNoTracking()
                   .FirstOrDefaultAsync(x => x.PhoneNumber.Substring(x.PhoneNumber.Length - 9) == phoneNumber.Substring(phoneNumber.Length - 9));
                }
                else if (phoneNumber.Length >= 10 && phoneNumber[^10] != '0')
                {
                    customer = await this.customerRepo.AllAsNoTracking()
                   .FirstOrDefaultAsync(x => x.PhoneNumber.Substring(x.PhoneNumber.Length - 10) == phoneNumber.Substring(phoneNumber.Length - 10));
                }
            }

            if (customer != null)
            {
                T model = await this.customerService.GetCustomerDetailsById<T>(customer.Id);
                return model;
            }

            return default;
        }

        public async Task<int> ShipmentsCountAsyncBySearchCriteria(string productType = null, string searchCustomerName = null, ShipmentSortingCriterion shipmentSortingCriterion = 0)
        {
            IQueryable<Shipment> shipments = this.shipmentRepo.AllAsNoTracking().AsQueryable();

            if (string.IsNullOrEmpty(productType) == false)
            {
                shipments = shipments.Where(x => x.ProductType == Enum.Parse<ProductType>(productType));
            }

            if (string.IsNullOrEmpty(searchCustomerName) == false)
            {
                searchCustomerName = $"%{searchCustomerName.Trim().ToLower()}%";

                shipments = shipments.Where(x => EF.Functions.Like(x.Sender.FirstName.ToLower() + " " + x.Sender.LastName.ToLower(), searchCustomerName)
                || EF.Functions.Like(x.Receiver.FirstName.ToLower() + " " + x.Receiver.LastName.ToLower(), searchCustomerName));
            }

            shipments = shipmentSortingCriterion switch
            {
                ShipmentSortingCriterion.Newest => shipments
                    .OrderByDescending(x => x.Id),
                ShipmentSortingCriterion.HighestPrice => shipments
                    .OrderByDescending(x => x.Price),
                _ => shipments,
            };

            return await shipments.CountAsync();
        }

        public async Task<IEnumerable<T>> GetAllShipmentsBySearchCriteria<T>(
            string productType = null,
            string searchCustomerName = null,
            ShipmentSortingCriterion shipmentSortingCriterion = 0,
            int page = 1,
            int itemsPerPage = 2)
        {
            IQueryable<Shipment> shipments = this.shipmentRepo.AllAsNoTracking().AsQueryable();

            if (string.IsNullOrEmpty(productType) == false)
            {
                shipments = shipments.Where(x => x.ProductType == Enum.Parse<ProductType>(productType));
            }

            if (string.IsNullOrEmpty(searchCustomerName) == false)
            {
                searchCustomerName = $"%{searchCustomerName.Trim().ToLower()}%";

                shipments = shipments.Where(x => EF.Functions.Like(x.Sender.FirstName.ToLower() + " " + x.Sender.LastName.ToLower(), searchCustomerName)
                || EF.Functions.Like(x.Receiver.FirstName.ToLower() + " " + x.Receiver.LastName.ToLower(), searchCustomerName));
            }

            shipments = shipmentSortingCriterion switch
            {
                 ShipmentSortingCriterion.Newest => shipments
                    .OrderByDescending(x => x.Id),
                 ShipmentSortingCriterion.HighestPrice => shipments
                    .OrderByDescending(x => x.Price),
                 _ => shipments,
            };

            List<T> model = await shipments
                .To<T>()
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToListAsync();

            return model;
        }
    }
}
