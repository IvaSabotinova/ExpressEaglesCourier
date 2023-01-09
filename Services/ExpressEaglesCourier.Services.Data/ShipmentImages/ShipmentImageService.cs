namespace ExpressEaglesCourier.Services.Data.ShipmentImages
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data.Common.Repositories;
    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    using static ExpressEaglesCourier.Common.GlobalConstants.ServicesConstants;

    public class ShipmentImageService : IShipmentImageService
    {
        private readonly IDeletableEntityRepository<ShipmentImage> shipmentImageRepo;

        public ShipmentImageService(IDeletableEntityRepository<ShipmentImage> shipmentImageRepo)
        {
            this.shipmentImageRepo = shipmentImageRepo;
        }

        public async Task<int> ShipmentImagesCountAsync(int shipmentId)
        {
            return await this.shipmentImageRepo.AllAsNoTracking()
                .Where(x => x.ShipmentId == shipmentId)
                .CountAsync();
        }

        public async Task<IEnumerable<T>> GetAllByShipmentId<T>(int shipmentId, int page = 1, int itemsPerPage = 2)
        {
            List<T> model = await this.shipmentImageRepo.AllAsNoTracking()
                .Where(x => x.ShipmentId == shipmentId)
                .To<T>()
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToListAsync();
            return model;
        }

        public async Task DeleteShipmentImageAsync(string id, string imagePath)
        {
            ShipmentImage image = await this.shipmentImageRepo.All()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (image == null)
            {
                throw new NullReferenceException(ImageNotFound);
            }

            string fullImagePath = Path.Combine(imagePath, $"{image.Id}.{image.Extension}");

            this.shipmentImageRepo.HardDelete(image);
            await this.shipmentImageRepo.SaveChangesAsync();

            if (File.Exists(fullImagePath))
            {
                File.Delete(fullImagePath);
            }
        }
    }
}
