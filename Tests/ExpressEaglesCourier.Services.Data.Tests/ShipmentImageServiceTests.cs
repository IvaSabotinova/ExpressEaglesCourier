namespace ExpressEaglesCourier.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data.Common.Repositories;
    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Services.Data.ShipmentImages;
    using ExpressEaglesCourier.Services.Mapping;
    using ExpressEaglesCourier.Web.ViewModels.ViewComponents.PagingShipmentImages;
    using MockQueryable.Moq;
    using Moq;
    using Xunit;

    public class ShipmentImageServiceTests
    {
        [Fact]
        public async Task GetAllByShipmentIdShouldReturnCorrectNumberOnPageTest()
        {
            Mock<IDeletableEntityRepository<ShipmentImage>> mockRepo = new Mock<IDeletableEntityRepository<ShipmentImage>>();

            ShipmentImageService shipmentImageService = new ShipmentImageService(mockRepo.Object);

            List<ShipmentImage> images = new List<ShipmentImage>()
            {
                new ShipmentImage()
                {
                     Id = "9d6b9d8a-b979-4acf-9713-6313a14675e1",
                     ShipmentId = 15,
                     Shipment = new Shipment() { TrackingNumber = "1111111111" },
                     Size = 1050,
                     Extension = "png",
                },
                new ShipmentImage()
                {
                     Id = "6526c59a-9d7d-4999-99d1-4666486d62b1",
                     ShipmentId = 15,
                     Shipment = new Shipment() { TrackingNumber = "1111111111" },
                     Size = 700,
                     Extension = "jpg",
                },
                new ShipmentImage()
                {
                    Id = "a143d1ae-a5c0-4327-9d30-7f4f19aef634",
                    Shipment = new Shipment() { TrackingNumber = "1111111111" },
                    ShipmentId = 15,
                    Size = 850,
                    Extension = "webp",
                },
            };

            mockRepo.Setup(x => x.AllAsNoTracking()).Returns(images.AsQueryable().BuildMock());

            AutoMapperConfig.RegisterMappings(Assembly.Load("ExpressEaglesCourier.Web.ViewModels"));

            IEnumerable<SingleShipmentImageViewModel> modelFirstPage = await shipmentImageService.GetAllByShipmentId<SingleShipmentImageViewModel>(15, 1, 2);

            IEnumerable<SingleShipmentImageViewModel> modelSecondPage = await shipmentImageService.GetAllByShipmentId<SingleShipmentImageViewModel>(15, 2, 2);

            Assert.Equal(2, modelFirstPage.Count());

            Assert.Single(modelSecondPage);

            Assert.Equal("a143d1ae-a5c0-4327-9d30-7f4f19aef634", modelSecondPage.First().Id);
        }
    }
}
