namespace ExpressEaglesCourier.Web.ViewModels.Feedbacks
{
    using System;

    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Data.Models.Enums;
    using ExpressEaglesCourier.Services.Mapping;

    public class FeedbackAllViewModel : IMapFrom<Feedback>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public FeedbackType? FeedbackType { get; set; }

        public string ApplicationUserUserName { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
