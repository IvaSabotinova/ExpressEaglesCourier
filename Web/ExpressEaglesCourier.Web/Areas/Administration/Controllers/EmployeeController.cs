namespace ExpressEaglesCourier.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Net.Mail;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Services.Data.Employees;
    using ExpressEaglesCourier.Web.ViewModels.Employees;
    using Microsoft.AspNetCore.Mvc;

    using static ExpressEaglesCourier.Common.GlobalConstants.ServicesConstants;

    public class EmployeeController : AdministrationController
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            EmployeeFormModel model = new EmployeeFormModel
            {
                Offices = this.employeeService.GetAllOfficesDetailsAsKeyValuePairs(),
                Positions = this.employeeService.GetAllPositionsAsKeyValuePairs(),
                Vehicles = this.employeeService.GetVehiclesAsKeyValuePairs(),
            };
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(EmployeeFormModel model)
        {
            if (!this.ModelState.IsValid)
            {
                model.Offices = this.employeeService.GetAllOfficesDetailsAsKeyValuePairs();
                model.Positions = this.employeeService.GetAllPositionsAsKeyValuePairs();
                model.Vehicles = this.employeeService.GetVehiclesAsKeyValuePairs();
                return this.View(model);
            }

            try
            {
                string id = await this.employeeService.CreateEmployeeAsync(model);
                this.TempData[Message] = EmployeeCreated;
                return this.RedirectToAction(nameof(this.Details), new { id });
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, InvalidEmployee);

                model.Offices = this.employeeService.GetAllOfficesDetailsAsKeyValuePairs();
                model.Positions = this.employeeService.GetAllPositionsAsKeyValuePairs();
                model.Vehicles = this.employeeService.GetVehiclesAsKeyValuePairs();

                this.TempData[Message] = ex.Message;
                return this.View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details([FromRoute] string id)
        {
            Employee employee = await this.employeeService.GetEmployeeById(id);

            if (employee == null)
            {
                return this.NotFound();
            }

            EmployeeDetailsViewModel model = await this.employeeService.GetEmployeeDetails(id);
            return this.View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            EmployeeFormModel model = await this.employeeService.GetEmployeeForEditAsync(id);

            model.Offices = this.employeeService.GetAllOfficesDetailsAsKeyValuePairs();
            model.Positions = this.employeeService.GetAllPositionsAsKeyValuePairs();
            model.Vehicles = this.employeeService.GetVehiclesAsKeyValuePairs();
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeFormModel model)
        {
            if (!this.ModelState.IsValid)
            {
                model.Offices = this.employeeService.GetAllOfficesDetailsAsKeyValuePairs();
                model.Positions = this.employeeService.GetAllPositionsAsKeyValuePairs();
                model.Vehicles = this.employeeService.GetVehiclesAsKeyValuePairs();
                return this.View(model);
            }

            try
            {
                await this.employeeService.EditEmployeeAsync(model);
                this.TempData[Message] = EmployeeDetailsAmended;
                return this.RedirectToAction(nameof(this.Details), new { id = model.Id });
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, InvalidEmployee);
                model.Offices = this.employeeService.GetAllOfficesDetailsAsKeyValuePairs();
                model.Positions = this.employeeService.GetAllPositionsAsKeyValuePairs();
                model.Vehicles = this.employeeService.GetVehiclesAsKeyValuePairs();
                this.TempData[Message] = ex.Message;
                return this.View(model);
            }
        }

        public async Task<IActionResult> Delete(string id)
        {
            await this.employeeService.DeleteEmployeeAsync(id);
            return this.RedirectToAction(nameof(DashboardController.Index), "Dashboard");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int shipmentId, int page = 1)
        {
            if (shipmentId < 1)
            {
                return this.NotFound();
            }

            const int ItemsPerPage = 3;
            try
            {
                EmployeeListAllViewModel model = new EmployeeListAllViewModel()
                {
                    ItemsPerPage = ItemsPerPage,
                    CurrentPageNumber = page,
                    AllItemsCount = await this.employeeService.GetEmployeesCountAsync(),
                    Employees = await this.employeeService.GetAllAsync<EmployeeAllViewModel>(page, ItemsPerPage),
                    ShipmentId = shipmentId,
                };

                return this.View(model);
            }
            catch (Exception)
            {
                return this.RedirectToAction("Details", "Shipment", new { shipmentId });
            }
        }
    }
}
