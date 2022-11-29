﻿namespace ExpressEaglesCourier.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Services.Data.Employees;
    using ExpressEaglesCourier.Services.Data.Shipments;
    using ExpressEaglesCourier.Web.ViewModels.Customers;
    using ExpressEaglesCourier.Web.ViewModels.Employee;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static ExpressEaglesCourier.Common.GlobalConstants.ServicesConstants;

    [Area("Administration")]
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet]
        [AllowAnonymous]

        public IActionResult Add()
        {
            var model = new EmployeeFormModel();
            model.Offices = this.employeeService.GetAllOfficesDetailsAsKeyValuePairs();
            model.Positions = this.employeeService.GetAllPositionsAsKeyValuePairs();
            model.Vehicles = this.employeeService.GetVehiclesAsKeyValuePairs();
            return this.View(model);
        }

        [HttpPost]
        [AllowAnonymous]

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
        [AllowAnonymous]

        public async Task<IActionResult> Details([FromRoute]string id)
        {
            EmployeeDetailsViewModel model = await this.employeeService.GetEmployeeDetails(id);
            return this.View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Edit(string id)
        {
            EmployeeFormModel model = await this.employeeService.GetEmployeeForEditAsync(id);

            model.Offices = this.employeeService.GetAllOfficesDetailsAsKeyValuePairs();
            model.Positions = this.employeeService.GetAllPositionsAsKeyValuePairs();
            model.Vehicles = this.employeeService.GetVehiclesAsKeyValuePairs();
            return this.View(model);
        }

        [HttpPost]
        [AllowAnonymous]
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

        [AllowAnonymous]
        public async Task<IActionResult> Delete(string id)
        {
            await this.employeeService.DeleteEmployeeAsync(id);
            return this.RedirectToAction("Index", "Home", new { area = string.Empty });
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll(int id)
        {
            try
            {
                IEnumerable<EmployeeAllViewModel> model = await this.employeeService.GetAllAsync(id);
                return this.View(model);
            }
            catch (Exception)
            {
                return this.RedirectToAction("Details", "Shipment", new { id });
            }
        }
    }
}