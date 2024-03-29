﻿namespace ExpressEaglesCourier.Common
{
    public static class GlobalConstants
    {
        public const string SystemName = "Express Eagles Courier";

        public const string AdministratorRoleName = "Administrator";

        public const string ManagerRoleName = "Manager";

        public const string EmployeeRoleName = "Employee";

        public const string CustomerUserRoleName = "CustomerUser";

        public static class EntitiesConstants
        {
            public const string HomeAddress = "Home Address";

            public const string HomeCity = "Home City";

            public const string HomeCountry = "Home Country";

            public const string DecimalType = "decimal(18,2)";

            public const int FirstNameMaxLength = 30;

            public const int FirstNameMinLength = 2;

            public const int MiddleNameMaxLength = 30;

            public const int LastNameMaxLength = 30;

            public const int LastNameMinLength = 2;

            public const int AddressMaxLength = 120;

            public const int AddressMinLength = 5;

            public const int CityNameMaxLength = 28;

            public const int CityNameMinLength = 2;

            public const int CityCodeMaxLength = 16;

            public const int CountryNameMaxLength = 56;

            public const int CountryNameMinLength = 3;

            public const int CountryCodeMaxLength = 16;

            public const int CompanyNameMaxLength = 100;

            public const int FeedbackTitleMinLength = 3;

            public const int FeedbackTitleMaxLength = 100;

            public const int FeedbackContentMinLength = 15;

            public const int FeedbackContentMaxLength = 7000;

            public const int FeedbackSenderNameMaxLength = 100;

            public const int PhoneNumberMaxLenght = 20;

            public const int PhoneNumberMinLenght = 6;

            public const int FaxNumberMaxLenght = 20;

            public const int EmailMaxLenght = 330;

            public const int EmailMinLength = 5;

            public const int JobTitleMaxLength = 50;

            public const int TrackingNumberMaxLength = 15;

            public const int TrackingNumberMinLength = 11;

            public const int VehicleModelNameMaxLenght = 30;

            public const int VehiclePlateNumberMaxLenght = 21;

            public const double ShipmentMaxWeightInKg = 70.00;

            public const double ShipmentMinWeightInKg = 0.01;

            public const string SameDayCourier = "Same-day Courier";

            public const string OvernightShipping = "Overnight Shipping";

            public const string StandardDeliveryService = "Standard-Delivery";

            public const string DoorToDoor = "Door-To-Door";

            public const string DoorToOffice = "Door-To-Office";

            public const string OfficeToDoor = "Office-To-Door";

            public const string OfficeToOffice = "Office-To-Office";

            public const string CarParts = "Car Parts";
        }

        public static class ViewModelConstants
        {
            public const int UserNameMaxLength = 50;

            public const int UserNameMinLength = 5;

            public const int PasswordMaxLength = 50;

            public const int PasswordMinLength = 5;

            public const string UserErrorMessage = "Invalid data!";

            public const string FirstName = "First Name";

            public const string MiddleName = "Middle Name (optional)";

            public const string MiddleNameEmployee = "Middle Name";

            public const string LastName = "Last Name";

            public const string CompanyName = "Company Name (optional)";

            public const string PhoneNumber = "Phone Number (00359xxxxxxxxx)";

            public const string TrackingNumber = "Tracking Number";

            public const string SenderFirstName = "Sender First Name";

            public const string SenderLastName = "Sender Last Name";

            public const string SenderPhoneNumber = "Sender Phone Number (00359xxxxxxxxx)";

            public const string ReceiverFirstName = "Receiver First Name";

            public const string ReceiverLastName = "Receiver Last Name";

            public const string ReceiverPhoneNumber = "Receiver Phone Number (00359xxxxxxxxx)";

            public const string PickUpAddress = "Pick-up Address";

            public const string PickUpTown = "Pick-up Town";

            public const string PickUpCountry = "Pick-up Country";

            public const string DestinationAddress = "Destination Address";

            public const string DestinationTown = "Destination Town";

            public const string DestinationCountry = "Destination Country";

            public const string BirthDate = "The Date Of Birth";

            public const string HireOnDate = "The Date Of Hiring";

            public const string SalaryEmployee = "Gross Salary In Leva";

            public const string ResignOnDate = "The Date Of Resignation";

            public const string Office = "Office";

            public const string Position = "Position";

            public const string Vehicle = "Vehicle";

            public const string DateTimeAcceptanceFromCustomer = "Date and time of acceptance from customer";

            public const string DateTimePickUpByCourier = "Date and time of pick-up by courier";

            public const string DateTimeSentFromOffice = "Date and time sent from office";

            public const string DateTimeArrivalAtOffice = "Date and time of arrival at office";

            public const string DateTimePrepForFinalDelivery = "Date and time of preparation for final delivery";

            public const string DateTimeFinalDelivery = "Date and time of final delivery";

            public const string OrderByHighestPrice = "Highest Price";

            public const int FirstAndLastNameMinLength = 5;

            public const int FirstAndLastNameMaxLength = 61;

            public const int AdditionalInfoForOrder = 220;
        }

        public static class ServicesConstants
        {
            public const string ClientExists = "Client with that name and phone number already exists!";

            public const string InvalidClientDetails = "Invalid client's details!";

            public const string ClientNotExist = "Client does not exist!";

            public const string InvalidShipmentDetails = "Invalid shipment's details!";

            public const string Message = "Message";

            public const string ShipmentCreated = "Shipment created successfully!";

            public const string TrackingNumberExistsInDB = "Shipment with this tracking number already exists!";

            public const string SenderWithPhoneNumberDoesNotExit = "Sender with this phone number does not exist! Please register as customer first or amend where necessary!";

            public const string ReceiverWithPhoneNumberDoesNotExit = "Receiver with this phone number does not exist! Please register as customer first or amend where necessary!!";

            public const string DuplicateTrackingNumbersNotAllowed = "There is another shipment with same tracking number in the database! Please check / amend as necessary!";

            public const string ShipmentNotExist = "Shipment not found!";

            public const string EmployeeNotExist = "Employee not found!";

            public const string CannotAddEmployeeToShipment = "Cannot add employee to shipment!";

            public const string EmployeeAlreadyAssignedWithShipment = "Employee already assigned with this shipment!";

            public const string ShipmentWithEmployeeNotExists = "Shipment with that employee does not exist!";

            public const string ShipmentAmendedSuccessfully = "Shipment details amended successfully!";

            public const string VehicleNotExist = "Vehicle does not exist!";

            public const string VehicleAssignedToShipment = "Vehicle already assigned to shipment"!;

            public const string ShipmentWithVehicleNotExist = "Shipment with that vehicle does not exist"!;

            public const string CustomerCreated = "Customer created successfully!";

            public const string CustomerDetailsAmended = "Customer details amended successfully!";

            public const string EmployeeExists = "Employee with that name and phone number already exists!";

            public const string EmployeeCreated = "New employee recorded successfully!";

            public const string InvalidEmployee = "Invalid employee's details!";

            public const string EmployeeDetailsAmended = "Employee details amended successfully!";

            public const string InvalidShipmentTrackingPathDetails = "Invalid shipment tracking path details!";

            public const string ShipmentTrackingPathCreated = "Shipment Tracking Path Created Successfully!";

            public const string ShipmentTrackingPathExist = "Tracking Path For The Shipment Already Created!";

            public const string TrackingNumberIncorrect = "Entered tracking number different from shipment tracking number!";

            public const string ShipmentTrackingPathNotExist = "Tracking path for the shipment does not exist!";

            public const string ShipmentTrackingPathUpdated = "Shipment Tracking Path Details Updated Successfully!";

            public const string TrackingPathNotFound = "Tracking path not found!";

            public const string CannotFindImages = "Images cannot be found!";

            public const string ImageNotFound = "Image not found!";

            public const string InvalidTrackingNumber = "You have entered invalid tracking number!";

            public const string FeedbackSuccessfullySent = "Thank you for your feedback! It will be dealt with shortly!";

            public const string SmthWentWrong = "Something went wrong! Please try again!";

            public const string FeedbackNotFound = "Feedback not found!";

            public const string FeedbackUpdated = "Feedback details updated successfully!";

            public const string InvalidFeedback = "Invalid feedback details!";
        }
    }
}
