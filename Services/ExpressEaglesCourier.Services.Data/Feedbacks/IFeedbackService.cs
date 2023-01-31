namespace ExpressEaglesCourier.Services.Data.Feedbacks
{
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Web.ViewModels.Feedbacks;

    public interface IFeedbackService
    {
        Task CreateAsync(string userId, FeedbackCreateModel model);
    }
}
