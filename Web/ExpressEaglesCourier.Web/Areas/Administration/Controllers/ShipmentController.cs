namespace ExpressEaglesCourier.Web.Areas.Administration.Controllers
{
    using System;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Services.Data.Employees;
    using ExpressEaglesCourier.Services.Data.Shipments;
    using ExpressEaglesCourier.Web.Controllers;
    using ExpressEaglesCourier.Web.ViewModels.Customers;
    using ExpressEaglesCourier.Web.ViewModels.Employee;
    using ExpressEaglesCourier.Web.ViewModels.Shipments;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static ExpressEaglesCourier.Common.GlobalConstants.ServicesConstants;

    [Authorize]
    [Area("Administration")]
    public class ShipmentController : BaseController
    {
        private readonly IShipmentService shipmentService;
        private readonly IEmployeeService employeeService;

        public ShipmentController(
            IShipmentService shipmentService,
            IEmployeeService employeeService)
        {
            this.shipmentService = shipmentService;
            this.employeeService = employeeService;
        }

        [HttpGet]
        [AllowAnonymous]

        public IActionResult Add()
        {
            ShipmentFormModel model = new ShipmentFormModel();
            return this.View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Add(ShipmentFormModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            int id;

            try
            {
                id = await this.shipmentService.CreateShipmentAsync(model);
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
        [AllowAnonymous]
        public async Task<IActionResult> Edit([FromRoute] int id)
        {
            ShipmentFormModel model = await this.shipmentService.GetShipmentForEditAsync(id);

            return this.View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Edit(ShipmentFormModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            try
            {
                await this.shipmentService.EditShipmentAsync(model);
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
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            if (!await this.shipmentService.ShipmentExists(id))
            {
                return this.BadRequest();
            }

            ShipmentDetailsViewModel model = await this.shipmentService.GetShipmentDetails(id);

            return this.View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AddEmployee(int shipmentId, string employeeId)
        {
            try
            {
                await this.shipmentService.AddEmployeeToShipment(shipmentId, employeeId);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, CannotAddEmployeeToShipment);

                this.TempData[Message] = ex.Message;
                return this.RedirectToAction(nameof(EmployeeController.GetAll), "Employee");
            }

            return this.RedirectToAction(nameof(this.Details), new { id = shipmentId });
        }

        [AllowAnonymous]
        public async Task<IActionResult> RemoveEmployee(int shipmentId, string employeeId)
        {
                await this.shipmentService.RemoveEmployeeFromShipmentAsync(shipmentId, employeeId);

                return this.RedirectToAction(nameof(this.Details), new { id = shipmentId });
        }

        [AllowAnonymous]
        public async Task<IActionResult> Delete(int id)
        {
            await this.shipmentService.DeleteShipmentAsync(id);
            return this.RedirectToAction(nameof(this.Add));
        }
    }
}
