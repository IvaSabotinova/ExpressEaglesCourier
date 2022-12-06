namespace ExpressEaglesCourier.Web.Areas.Employee.Controllers
{
    using System;
    using System.Data;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Services.Data.Employees;
    using ExpressEaglesCourier.Services.Data.ShipmentTrackingPaths;
    using ExpressEaglesCourier.Web.ViewModels.ShipmentTrackingPaths;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static ExpressEaglesCourier.Common.GlobalConstants;
    using static ExpressEaglesCourier.Common.GlobalConstants.ServicesConstants;

    public class ShipmentTrackingPathController : StaffController
    {
        private readonly IShipmentTrackingPathService shipmentTrackingPathService;
        private readonly IEmployeeService employeeService;

        public ShipmentTrackingPathController(
            IShipmentTrackingPathService shipmentTrackingPathService,
            IEmployeeService employeeService)
        {
            this.shipmentTrackingPathService = shipmentTrackingPathService;
            this.employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            ShipmentTrackingPathFormModel model = new ShipmentTrackingPathFormModel();
            model.ShipmentId = id;
            model.TrackingNumber = this.shipmentTrackingPathService.GetShipmentById(id).Result.TrackingNumber;
            model.Offices_Dispatch = this.employeeService.GetAllOfficesDetailsAsKeyValuePairs();
            model.Offices_Receipt = this.employeeService.GetAllOfficesDetailsAsKeyValuePairs();
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ShipmentTrackingPathFormModel model)
        {
            if (!this.ModelState.IsValid)
            {
                model.Offices_Dispatch = this.employeeService.GetAllOfficesDetailsAsKeyValuePairs();
                model.Offices_Receipt = this.employeeService.GetAllOfficesDetailsAsKeyValuePairs();
                return this.View(model);
            }

            try
            {
                int shipmentTrackingPathId = await this.shipmentTrackingPathService.CreateShipmentTrackingPathAsync(model);

                this.TempData[Message] = ShipmentTrackingPathCreated;

                return this.RedirectToAction(nameof(this.Details), new { id = shipmentTrackingPathId });
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, InvalidShipmentTrackingPathDetails);

                model.Offices_Dispatch = this.employeeService.GetAllOfficesDetailsAsKeyValuePairs();
                model.Offices_Receipt = this.employeeService.GetAllOfficesDetailsAsKeyValuePairs();

                this.TempData[Message] = ex.Message;
                return this.View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            ShipmentTrackingPathDetailsViewModel model = await this.shipmentTrackingPathService.Details(id);
            return this.View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Update([FromRoute] int id)
        {
            ShipmentTrackingPathFormModel model = await this.shipmentTrackingPathService.GetTrackingPathForUpdate(id);
            model.Offices_Dispatch = this.employeeService.GetAllOfficesDetailsAsKeyValuePairs();
            model.Offices_Receipt = this.employeeService.GetAllOfficesDetailsAsKeyValuePairs();

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ShipmentTrackingPathFormModel model)
        {
            if (!this.ModelState.IsValid)
            {
                model.Offices_Dispatch = this.employeeService.GetAllOfficesDetailsAsKeyValuePairs();
                model.Offices_Receipt = this.employeeService.GetAllOfficesDetailsAsKeyValuePairs();
                return this.View(model);
            }

            try
            {
                await this.shipmentTrackingPathService.UpdateShipmentTrackingPathAsync(model);
                this.TempData[Message] = ShipmentTrackingPathUpdated;
                return this.RedirectToAction(nameof(this.Details), new { id = model.Id });
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, InvalidShipmentTrackingPathDetails);

                this.TempData[Message] = ex.Message;
                return this.View(model);
            }
        }

        [Authorize(Roles = ManagerRoleName + ", " + AdministratorRoleName)]
        public async Task<IActionResult> Delete(int id)
        {
            await this.shipmentTrackingPathService.DeleteTrackingPathAsync(id);
            return this.RedirectToAction("Index", "Dashboard", new { area = "Administration" });
        }
    }
}
