namespace ExpressEaglesCourier.Services.Data.ShipmentImages
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IShipmentImageService
    {
        Task<int> ShipmentImagesCountAsync(int shipmentId);

        Task<IEnumerable<T>> GetAllByShipmentId<T>(int shipmentId, int page, int itemsPerPage);

        Task DeleteShipmentImageAsync(string id, string imagePath);
    }
}
