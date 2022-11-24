namespace ExpressEaglesCourier.Services.Data.Shipments
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data.Common.Repositories;
    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Web.ViewModels.Employee;
    using ExpressEaglesCourier.Web.ViewModels.Shipments;
    using Microsoft.EntityFrameworkCore;

    using static ExpressEaglesCourier.Common.GlobalConstants.ServicesConstants;

    public class ShipmentService : IShipmentService
    {
        private readonly IDeletableEntityRepository<Shipment> shipmentRepo;
        private readonly IDeletableEntityRepository<Customer> customerRepo;
        private readonly IDeletableEntityRepository<Employee> employeeRepo;
        private readonly IDeletableEntityRepository<EmployeeShipment> employeeShipmentRepo;

        public ShipmentService(
            IDeletableEntityRepository<Shipment> shipmentRepo,
            IDeletableEntityRepository<Customer> customerRepo,
            IDeletableEntityRepository<Employee> employeeRepo,
            IDeletableEntityRepository<EmployeeShipment> employeeShipmentRepo)
        {
            this.shipmentRepo = shipmentRepo;
            this.customerRepo = customerRepo;
            this.employeeRepo = employeeRepo;
            this.employeeShipmentRepo = employeeShipmentRepo;
        }

        public async Task<int> CreateShipmentAsync(ShipmentFormModel model)
        {
            if (await this.TrackingNumberExists(model.TrackingNumber))
            {
                throw new ArgumentException(TrackingNumberExistsInDB);
            }

            if (await this.CustomerWithPhoneNumberExists(model.SenderFirstName, model.SenderLastName, model.SenderPhoneNumber) == false)
            {
                throw new ArgumentException(SenderWithPhoneNumberDoesNotExit);
            }

            if (await this.CustomerWithPhoneNumberExists(model.ReceiverFirstName, model.ReceiverLastName, model.ReceiverPhoneNumber) == false)
            {
                throw new ArgumentException(ReceiverWithPhoneNumberDoesNotExit);
            }

            string senderId = await this.GetCustomerId(model.SenderFirstName, model.SenderLastName, model.SenderPhoneNumber);

            string receiverId = await this.GetCustomerId(model.ReceiverFirstName, model.ReceiverLastName, model.ReceiverPhoneNumber);

            Shipment newShipment = new Shipment()
            {
                TrackingNumber = model.TrackingNumber,
                SenderId = senderId,
                ReceiverId = receiverId,
                PickupAddress = model.PickUpAddress,
                PickUpTown = model.PickUpTown,
                PickUpCountry = model.PickUpCountry,
                DestinationAddress = model.DestinationAddress,
                DestinationTown = model.DestinationTown,
                DestinationCountry = model.DestinationCountry,
                Weight = model.Weight,
                DeliveryWay = model.DeliveryWay,
                DeliveryType = model.DeliveryType,
                ProductType = model.ProductType,
                Price = model.Price,
            };

            await this.shipmentRepo.AddAsync(newShipment);
            await this.shipmentRepo.SaveChangesAsync();

            return newShipment.Id;
        }

       /// <summary>
       /// Checks whether one exists as tracking numbers should not be duplicated.
       /// </summary>
       /// <param name="trackingNumber"></param>
       /// <returns></returns>
        public async Task<bool> TrackingNumberExists(string trackingNumber)
        {
            return await this.shipmentRepo.AllAsNoTracking().Select(x => x.TrackingNumber).ContainsAsync(trackingNumber);
        }

        /// <summary>
        /// For a courier a customer is identified by first name, last name and a phone number - one should match all these three.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public async Task<bool> CustomerWithPhoneNumberExists(string firstName, string lastName, string phoneNumber)
        {
            return await this.customerRepo.AllAsNoTracking().AnyAsync(x => x.FirstName == firstName && x.LastName == lastName && x.PhoneNumber == phoneNumber);
        }

        /// <summary>
        /// For a courier a customer is identified by first name, last name and a phone number - one should match all these three.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Client not exists.</exception>
        public async Task<string> GetCustomerId(string firstName, string lastName, string phoneNumber)
        {
            Customer customer = await this.customerRepo.AllAsNoTracking().FirstOrDefaultAsync(x => x.FirstName == firstName && x.LastName == lastName && x.PhoneNumber == phoneNumber);

            if (customer == null)
            {
                throw new ArgumentException(ClientNotExist);
            }

            return customer.Id;
        }

        public async Task<ShipmentFormModel> GetShipmentForEditAsync(int shipmentId)
        {
            Shipment shipment = await this.shipmentRepo.All()
                .Include(x => x.Sender)
                .Include(x => x.Receiver)
                .FirstOrDefaultAsync(x => x.Id == shipmentId);

            ShipmentFormModel model = new ShipmentFormModel()
            {
                Id = shipment.Id,
                TrackingNumber = shipment.TrackingNumber,
                SenderFirstName = shipment.Sender.FirstName,
                SenderLastName = shipment.Sender.LastName,
                SenderPhoneNumber = shipment.Sender.PhoneNumber,
                ReceiverFirstName = shipment.Receiver.FirstName,
                ReceiverLastName = shipment.Receiver.LastName,
                ReceiverPhoneNumber = shipment.Receiver.PhoneNumber,
                PickUpAddress = shipment.PickupAddress,
                PickUpTown = shipment.PickUpTown,
                PickUpCountry = shipment.PickUpCountry,
                DestinationAddress = shipment.DestinationAddress,
                DestinationTown = shipment.DestinationTown,
                DestinationCountry = shipment.DestinationCountry,
                Weight = shipment.Weight,
                DeliveryWay = shipment.DeliveryWay,
                DeliveryType = shipment.DeliveryType,
                ProductType = shipment.ProductType,
                Price = shipment.Price,
            };

            return model;
        }

        public async Task EditShipmentAsync(ShipmentFormModel model)
        {
            if (await this.CustomerWithPhoneNumberExists(model.SenderFirstName, model.SenderLastName, model.SenderPhoneNumber) == false)
            {
                throw new ArgumentException(SenderWithPhoneNumberDoesNotExit);
            }

            if (await this.CustomerWithPhoneNumberExists(model.ReceiverFirstName, model.ReceiverLastName, model.ReceiverPhoneNumber) == false)
            {
                throw new ArgumentException(ReceiverWithPhoneNumberDoesNotExit);
            }

            string senderId = await this.GetCustomerId(model.SenderFirstName, model.SenderLastName, model.SenderPhoneNumber);

            string receiverId = await this.GetCustomerId(model.ReceiverFirstName, model.ReceiverLastName, model.ReceiverPhoneNumber);

            Shipment shipment = await this.shipmentRepo.All().FirstOrDefaultAsync(x => x.Id == model.Id);

            if (shipment == null)
            {
                throw new ArgumentException(ShipmentNotExist);
            }

            shipment.TrackingNumber = model.TrackingNumber;
            shipment.SenderId = senderId;
            shipment.ReceiverId = receiverId;
            shipment.PickupAddress = model.PickUpAddress;
            shipment.PickUpTown = model.PickUpTown;
            shipment.PickUpCountry = model.PickUpCountry;
            shipment.DestinationAddress = model.DestinationAddress;
            shipment.DestinationTown = model.DestinationTown;
            shipment.DestinationCountry = model.DestinationCountry;
            shipment.Weight = model.Weight;
            shipment.DeliveryWay = model.DeliveryWay;
            shipment.DeliveryType = model.DeliveryType;
            shipment.ProductType = model.ProductType;
            shipment.Price = model.Price;

            await this.shipmentRepo.SaveChangesAsync();
        }

        /// <summary>
        /// Gets the details of a particular shipment by id to be displayed.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ShipmentDetailsViewModel> GetShipmentDetails(int id)
        {
            return await this.shipmentRepo.AllAsNoTracking()
                .Where(x => x.Id == id)
                .Select(x => new ShipmentDetailsViewModel()
                {
                    Id = x.Id,
                    TrackingNumber = x.TrackingNumber,
                    SenderFullName = $"{x.Sender.FirstName} {x.Sender.LastName}",
                    SenderPhoneNumber = x.Sender.PhoneNumber,
                    ReceiverFullName = $"{x.Receiver.FirstName} {x.Receiver.LastName}",
                    ReceiverPhoneNumber = x.Receiver.PhoneNumber,
                    FullPickUpAddress = $"{x.PickupAddress}, {x.PickUpTown}, {x.PickUpCountry}",
                    FullDestinationAddress = $"{x.DestinationAddress}, {x.DestinationTown}, {x.DestinationCountry}",
                    DeliveryWay = x.DeliveryWay.ToString(),
                    DeliveryType = x.DeliveryType.ToString(),
                    ProductType = x.ProductType.ToString(),
                    Weight = x.Weight,
                    Price = x.Price,
                    EmployeesShipments = x.EmployeesShipments.Select(es =>
                    new EmployeeShipmentViewModel()
                    {
                        EmployeeId = es.EmployeeId,
                        FullName = $"{es.Employee.FirstName} {es.Employee.LastName}",
                        Position = es.Employee.Position.JobTitle,
                        OfficeCity = es.Employee.Office.City.Name,
                    }),
                }).FirstOrDefaultAsync();
        }

        public async Task<bool> ShipmentExists(int id)
        => await this.shipmentRepo.AllAsNoTracking().AnyAsync(x => x.Id == id);

        /// <summary>
        /// Assigning an employee to take part in handling a shipment.
        /// </summary>
        /// <param name="shipmentId"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Employee with that shipment exists.</exception>
        public async Task AddEmployeeToShipment(int shipmentId, string employeeId)
        {
            if (!await this.ShipmentExists(shipmentId))
            {
                throw new ArgumentException(ShipmentNotExist);
            }

            Employee employee = await this.employeeRepo.AllAsNoTracking().FirstOrDefaultAsync(x => x.Id == employeeId);

            if (employee == null)
            {
                throw new ArgumentException(EmployeeNotExist);
            }

            EmployeeShipment employeeShipment = await this.employeeShipmentRepo.AllAsNoTracking()
                .FirstOrDefaultAsync(x => x.EmployeeId == employeeId && x.ShipmentId == shipmentId);

            if (employeeShipment != null)
            {
                throw new ArgumentException(EmployeeWithShipmentAlreadyExists);
            }

            EmployeeShipment newEmployeeShipment = new EmployeeShipment()
            {
                EmployeeId = employeeId,
                ShipmentId = shipmentId,
            };

            await this.employeeShipmentRepo.AddAsync(newEmployeeShipment);

            await this.shipmentRepo.SaveChangesAsync();
        }

        /// <summary>
        /// Withdrawing an employee from taking part in handling a shipment due to any reason - other obligations, changes in working schedule, other priorities etc. An entry in mapping table EmployeeShipment is therefore unnecessary hereof the hard delete.
        /// </summary>
        /// <param name="shipmentId"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Shipment with that employee does not exist.</exception>
        public async Task RemoveEmployeeFromShipmentAsync(int shipmentId, string employeeId)
        {
            EmployeeShipment employeeShipment = await this.employeeShipmentRepo.All().FirstOrDefaultAsync(x => x.ShipmentId == shipmentId && x.EmployeeId == employeeId);

            if (employeeShipment == null)
            {
                throw new ArgumentException(ShipmentWithEmployeeNotExists);
            }

            this.employeeShipmentRepo.HardDelete(employeeShipment);

            await this.employeeShipmentRepo.SaveChangesAsync();
        }

        /// <summary>
        /// Deletion after cancelling a shipment.
        /// </summary>
        /// <param name="shipmentId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Shipment does not exist.</exception>
        public async Task DeleteShipmentAsync(int shipmentId)
        {
            //List<EmployeeShipment> shipmentEmployees = await this.employeeShipmentRepo.All().Where(x => x.ShipmentId == shipmentId).ToListAsync();

            if (!await this.ShipmentExists(shipmentId))
            {
                throw new ArgumentException(ShipmentNotExist);
            }

            Shipment shipment = await this.shipmentRepo.All().FirstOrDefaultAsync(x => x.Id == shipmentId);

            this.shipmentRepo.Delete(shipment);

            await this.shipmentRepo.SaveChangesAsync();
        }
    }
}
