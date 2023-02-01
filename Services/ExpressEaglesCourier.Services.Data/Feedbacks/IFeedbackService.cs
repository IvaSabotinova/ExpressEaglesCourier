namespace ExpressEaglesCourier.Services.Data.Feedbacks
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Web.ViewModels.Feedbacks;

    public interface IFeedbackService
    {
        Task CreateAsync(string userId, FeedbackCreateModel model);

        Task<IEnumerable<T>> GetAll<T>();
    }
}
