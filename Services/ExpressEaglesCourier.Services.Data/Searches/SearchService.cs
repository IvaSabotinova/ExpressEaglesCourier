namespace ExpressEaglesCourier.Services.Data.Searches
{
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data.Common.Repositories;
    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Services.Data.Customers;
    using ExpressEaglesCourier.Services.Data.Employees;
    using ExpressEaglesCourier.Services.Data.Shipments;
    using ExpressEaglesCourier.Services.Data.ShipmentTrackingPaths;
    using ExpressEaglesCourier.Web.ViewModels.Customers;
    using ExpressEaglesCourier.Web.ViewModels.Employees;
    using ExpressEaglesCourier.Web.ViewModels.Shipments;
    using ExpressEaglesCourier.Web.ViewModels.ShipmentTrackingPaths;
    using Microsoft.EntityFrameworkCore;

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
                    this.shipmentTrackingPathService.Details(trackingPath.Id);

                return model;
            }

            return null;
        }

        public async Task<ShipmentDetailsViewModel> SearchShipmentByTrackingNumberAsync(string trackingNumber)
        {
           Shipment shipment = await this.shipmentRepo.AllAsNoTracking()
                .FirstOrDefaultAsync(x => x.TrackingNumber == trackingNumber);

           if (shipment != null)
            {
                ShipmentDetailsViewModel model = await this.shipmentService.GetShipmentDetails(shipment.Id);
                return model;
            }

           return null;
        }

        public async Task<EmployeeDetailsViewModel> SearchEmployeeByPhoneNumberAsync(string phoneNumber)
        {
            Employee employee = await this.employeeRepo.AllAsNoTracking()
               .FirstOrDefaultAsync(x => x.PhoneNumber == phoneNumber);

            if (employee != null)
            {
                EmployeeDetailsViewModel model = await this.employeeService.GetEmployeeDetails(employee.Id);
                return model;
            }

            return null;
        }

        public async Task<CustomerDetailsViewModel> SearchCustomerByPhoneNumberAsync(string phoneNumber)
        {
            Customer customer = await this.customerRepo.AllAsNoTracking()
               .FirstOrDefaultAsync(x => x.PhoneNumber == phoneNumber);

            if (customer != null)
            {
                CustomerDetailsViewModel model = await this.customerService.GetCustomerDetailsById(customer.Id);
                return model;
            }

            return null;
        }
    }
}
