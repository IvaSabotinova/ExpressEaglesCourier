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

        public async Task<IEnumerable<T>> GetAll<T>()
        => await this.feedbackRepo.AllAsNoTracking()
                .OrderByDescending(x => x.CreatedOn)
                .To<T>()
                .ToListAsync();
    }
}
