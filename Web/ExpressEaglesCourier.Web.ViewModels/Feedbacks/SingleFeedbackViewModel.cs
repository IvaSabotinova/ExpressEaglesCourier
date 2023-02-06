namespace ExpressEaglesCourier.Web.ViewModels.Feedbacks
{
    using AutoMapper;
    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Data.Models.Enums;
    using ExpressEaglesCourier.Services.Mapping;

    public class SingleFeedbackViewModel : IMapFrom<Feedback>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public FeedbackType? FeedbackType { get; set; } = null;

        public string ShipmentTrackingNumber { get; set; } = null;

        public string SenderName { get; set; } = null;

        public string ApplicationUserUserName { get; set; }

        public string ApplicationUserCustomerFullName { get; set; } = null;

        public string ApplicationUserCustomerPhoneNumber { get; set; } = null;

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Feedback, SingleFeedbackViewModel>()
                .ForMember(x => x.ApplicationUserCustomerFullName, opt => opt.MapFrom(x => x.ApplicationUser.Customer.FirstName + " " + x.ApplicationUser.Customer.LastName))
                .ForMember(x => x.ApplicationUserCustomerPhoneNumber, opt => opt.MapFrom(x => x.ApplicationUser.Customer.PhoneNumber ?? x.ApplicationUser.PhoneNumber));
        }
    }
}
