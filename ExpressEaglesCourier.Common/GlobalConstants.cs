namespace ExpressEaglesCourier.Common
{
    public static class GlobalConstants
    {
        public const string SystemName = "Express Eagles Courier";

        public const string AdministratorRoleName = "Administrator";

        public static class EntitiesConstants
        {
            public const string HomeAddress = "Home address";

            public const string HomeCity = "Home city";

            public const string HomeCountry = "Home country";

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

            public const int FeedbackLengthMaxLength = 7000;

            public const int PhoneNumberMaxLenght = 20;

            public const int PhoneNumberMinLenght = 6;

            public const int FaxNumberMaxLenght = 20;

            public const int EmailMaxLenght = 330;

            public const int EmailMinLength = 5;

            public const int JobTitleMaxLength = 50;

            public const int TrackingNumberMaxLength = 15;

            public const int VehicleModelNameMaxLenght = 30;

            public const int VehiclePlateNumberMaxLenght = 21;

            public const double ShipmentMaxWeightInGrams = 70000;
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

            public const string LastName = "Last Name";

            public const string CompanyName = "Company Name (optional)";

            public const string PhoneNumber = "Phone Number";
        }

        public static class ServicesConstants
        {
            public const string ClientExists = "Client already exists";

            public const string InvalidClientDetails = "Invalid client's details!";

            public const string ClientNotExist = "Client does not exist!";
        }
    }
}
