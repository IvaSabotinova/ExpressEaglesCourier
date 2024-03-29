﻿namespace ExpressEaglesCourier.Services.Data.Feedbacks
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Web.ViewModels.Feedbacks;

    public interface IFeedbackService
    {
        Task CreateAsync(string userId, FeedbackCreateModel model);

        Task<T> GetById<T>(int id);

        Task<Feedback> GetFeedbackById(int id);

        Task EditAsync(FeedbackEditModel model);

        Task<IEnumerable<T>> GetAll<T>();

        Task SoftDeleteAsync(int id);

        Task HardDeleteAsync(int id);
    }
}
