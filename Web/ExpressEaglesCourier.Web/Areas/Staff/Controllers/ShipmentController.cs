namespace ExpressEaglesCourier.Web.Areas.Employee.Controllers
{
    using System;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Services.Data.Employees;
    using ExpressEaglesCourier.Services.Data.Shipments;
    using ExpressEaglesCourier.Web.ViewModels.Shipments;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;

    using static ExpressEaglesCourier.Common.GlobalConstants;
    using static ExpressEaglesCourier.Common.GlobalConstants.ServicesConstants;

    public class ShipmentController : StaffController
    {
        private readonly IShipmentService shipmentService;
        private readonly IWebHostEnvironment environment;

        public ShipmentController(
            IShipmentService shipmentService,
            IWebHostEnvironment environment)
        {
            this.shipmentService = shipmentService;
            this.environment = environment;
        }

        [HttpGet]
        public IActionResult Add()
        {
            ShipmentFormModel model = new ShipmentFormModel();
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ShipmentFormModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            int id;

            try
            {
                id = await this.shipmentService.CreateShipmentAsync(model, $"{this.environment.WebRootPath}/images");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, InvalidShipmentDetails);

                this.TempData[Message] = ex.Message;
                return this.View(model);
            }

            this.TempData[Message] = ShipmentCreated;

            return this.RedirectToAction(nameof(this.Details), new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Edit([FromRoute] int id)
        {
            ShipmentFormModel model = await this.shipmentService.GetShipmentForEditAsync(id);
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ShipmentFormModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            try
            {
                await this.shipmentService.EditShipmentAsync(model, $"{this.environment.WebRootPath}/images");
                this.TempData[Message] = ShipmentAmendedSuccessfully;
                return this.RedirectToAction(nameof(this.Details), new { id = model.Id });
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, InvalidShipmentDetails);

                this.TempData[Message] = ex.Message;
                return this.View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (!await this.shipmentService.ShipmentExists(id))
            {
                return this.NotFound();
            }

            ShipmentDetailsViewModel model = await this.shipmentService.GetShipmentDetails(id);
            return this.View(model);
        }

        [Authorize(Roles = AdministratorRoleName + "," + ManagerRoleName)]
        [HttpPost]
        public async Task<IActionResult> AddEmployee(int shipmentId, string employeeId)
        {
            if (shipmentId < 1)
            {
                return this.NotFound();
            }

            try
            {
                await this.shipmentService.AddEmployeeToShipment(shipmentId, employeeId);
                return this.RedirectToAction(nameof(this.Details), new { id = shipmentId });
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, CannotAddEmployeeToShipment);

                this.TempData[Message] = ex.Message;
                return this.RedirectToAction(nameof(this.Details), new { id = shipmentId });
            }
        }

        [Authorize(Roles = AdministratorRoleName + "," + ManagerRoleName)]
        public async Task<IActionResult> RemoveEmployee(int shipmentId, string employeeId)
        {
            await this.shipmentService.RemoveEmployeeFromShipmentAsync(shipmentId, employeeId);

            return this.RedirectToAction(nameof(this.Details), new { id = shipmentId });
        }

        [Authorize(Roles = AdministratorRoleName + "," + ManagerRoleName)]
        public async Task<IActionResult> Delete(int id)
        {
            await this.shipmentService.DeleteShipmentAsync(id);
            return this.RedirectToAction(nameof(this.Add));
        }
    }
}
