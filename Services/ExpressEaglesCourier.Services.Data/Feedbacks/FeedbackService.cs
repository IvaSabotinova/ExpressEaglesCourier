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
    using Microsoft.EntityFrameworkCore;

    using static ExpressEaglesCourier.Common.GlobalConstants.ServicesConstants;

    public class FeedbackService : IFeedbackService
    {
        private readonly IDeletableEntityRepository<Feedback> feedbackRepo;
        private readonly IDeletableEntityRepository<Shipment> shipmentRepo;
        private readonly IShipmentService shipmentService;

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
            if (model.ShipmentTrackingNumber != null
                && await this.shipmentService.TrackingNumberExists(model.ShipmentTrackingNumber) == false)
            {
                throw new NullReferenceException(InvalidTrackingNumber);
            }

            Feedback newFeedback = AutoMapperConfig.MapperInstance.Map<Feedback>(model);

            newFeedback.ApplicationUserId = userId;

            Shipment shipment = await this.shipmentRepo.AllAsNoTracking()
                .FirstOrDefaultAsync(x => x.TrackingNumber == model.ShipmentTrackingNumber);

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
           feedback.Title = model.Title ?? null;
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
    }
}
