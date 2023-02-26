namespace ExpressEaglesCourier.Services.Data.Feedbacks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data.Common.Repositories;
    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Services.Data.Shipments;
    using ExpressEaglesCourier.Services.Mapping;
    using ExpressEaglesCourier.Web.ViewModels.Feedbacks;
    using Ganss.Xss;
    using Microsoft.EntityFrameworkCore;

    using static ExpressEaglesCourier.Common.GlobalConstants.ServicesConstants;

    public class FeedbackService : IFeedbackService
    {
        private readonly IDeletableEntityRepository<Feedback> feedbackRepo;
        private readonly IDeletableEntityRepository<Shipment> shipmentRepo;
        private readonly IShipmentService shipmentService;
        private readonly HtmlSanitizer sanitizer = new HtmlSanitizer();

        public FeedbackService(
            IDeletableEntityRepository<Feedback> feedbackRepo,
            IDeletableEntityRepository<Shipment> shipmentRepo,
            IShipmentService shipmentService)
        {
            this.feedbackRepo = feedbackRepo;
            this.shipmentRepo = shipmentRepo;
            this.shipmentService = shipmentService;
        }

        public async Task CreateAsync(string userId, FeedbackCreateModel model)
        {
            string sanitizedTrackingNumber = this.sanitizer.Sanitize(model.ShipmentTrackingNumber);

            if (!string.IsNullOrWhiteSpace(sanitizedTrackingNumber)
                && await this.shipmentService.TrackingNumberExists(sanitizedTrackingNumber) == false)
            {
                throw new NullReferenceException(InvalidTrackingNumber);
            }

            Shipment shipment = await this.shipmentRepo.AllAsNoTracking()
              .FirstOrDefaultAsync(x => x.TrackingNumber == sanitizedTrackingNumber);

            Feedback newFeedback = new Feedback()
            {
                Title = this.sanitizer.Sanitize(model.Title),
                Content = this.sanitizer.Sanitize(model.Content),
                SenderName = this.sanitizer.Sanitize(model.SenderName),
            };

            newFeedback.ApplicationUserId = userId;

            if (shipment != null)
            {
                newFeedback.ShipmentId = shipment.Id;
            }

            await this.feedbackRepo.AddAsync(newFeedback);
            await this.feedbackRepo.SaveChangesAsync();
        }

        public async Task<T> GetById<T>(int id)
        => await this.feedbackRepo.AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefaultAsync();

        public async Task<Feedback> GetFeedbackById(int id)
       => await this.feedbackRepo.AllAsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

        public async Task EditAsync(FeedbackEditModel model)
        {
           Shipment shipment = null;

           if (model.ShipmentTrackingNumber != null)
           {
                shipment = await this.shipmentRepo.AllAsNoTracking()
               .FirstOrDefaultAsync(x => x.TrackingNumber == model.ShipmentTrackingNumber);
                if (shipment == null)
                {
                    throw new NullReferenceException(ShipmentNotExist);
                }
           }

           Feedback feedback = await this.feedbackRepo.All()
                 .FirstOrDefaultAsync(x => x.Id == model.Id);

           if (feedback == null)
           {
                throw new NullReferenceException(FeedbackNotFound);
           }

           feedback.Id = model.Id;
           feedback.SenderName = model.SenderName ?? null;
           feedback.Title = model.Title;
           feedback.Content = model.Content;
           feedback.FeedbackType = model.FeedbackType ?? null;
           feedback.ShipmentId = shipment?.Id ?? null;

           await this.feedbackRepo.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll<T>()
        => await this.feedbackRepo.AllAsNoTracking()
                .OrderByDescending(x => x.CreatedOn)
                .To<T>()
                .ToListAsync();

        public async Task SoftDeleteAsync(int id)
        {
            Feedback feedback = await this.GetFeedbackById(id);

            this.feedbackRepo.Delete(feedback);
            await this.feedbackRepo.SaveChangesAsync();
        }

        public async Task HardDeleteAsync(int id)
        {
            Feedback feedback = await this.GetFeedbackById(id);

            this.feedbackRepo.HardDelete(feedback);
            await this.feedbackRepo.SaveChangesAsync();
        }
    }
}
