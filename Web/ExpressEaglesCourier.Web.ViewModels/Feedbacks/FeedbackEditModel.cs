namespace ExpressEaglesCourier.Web.ViewModels.Feedbacks
{
    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Data.Models.Enums;
    using ExpressEaglesCourier.Services.Mapping;

    public class FeedbackEditModel : FeedbackCreateModel, IMapFrom<Feedback>
    {
        public int Id { get; set; }

        public FeedbackType? FeedbackType { get; set; } = null;
    }
}
