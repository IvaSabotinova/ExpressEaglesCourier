namespace ExpressEaglesCourier.Web.ViewModels.Feedbacks
{
    using AutoMapper;
    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Services.Mapping;

    public class SingleFeedbackViewModel : FeedbackDeleteViewModel, IMapFrom<Feedback>, IHaveCustomMappings
    {
        public string SenderName { get; set; } = null;

        public string ApplicationUserCustomerPhoneNumber { get; set; } = null;

        public new void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Feedback, SingleFeedbackViewModel>()
                .ForMember(x => x.ApplicationUserCustomerFullName, opt => opt.MapFrom(x => x.ApplicationUser.Customer.FirstName + " " + x.ApplicationUser.Customer.LastName))
                .ForMember(x => x.ApplicationUserCustomerPhoneNumber, opt => opt.MapFrom(x => x.ApplicationUser.Customer.PhoneNumber ?? x.ApplicationUser.PhoneNumber));
        }
    }
}
