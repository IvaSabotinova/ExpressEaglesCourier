namespace ExpressEaglesCourier.Web.Areas.Employee.Controllers
{
    using System;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Services.Data.Customers;
    using ExpressEaglesCourier.Web.ViewModels.Customers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static ExpressEaglesCourier.Common.GlobalConstants;
    using static ExpressEaglesCourier.Common.GlobalConstants.ServicesConstants;

    public class CustomerController : StaffController
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            CustomerFormModel model = new CustomerFormModel();

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CustomerFormModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            try
            {
                string id = await this.customerService.CreateCustomerAsync(model);
                this.TempData[Message] = CustomerCreated;
                return this.RedirectToAction(nameof(this.Details), new { id });
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, InvalidClientDetails);
                this.TempData[Message] = ex.Message;
                return this.View(model);
            }
        }

        [HttpGet]
        [Authorize(Roles = ManagerRoleName + ", " + AdministratorRoleName + ", " + EmployeeRoleName)]
        public async Task<IActionResult> Details([FromRoute] string id)
        {
            Customer customer = await this.customerService.GetCustomerById(id);
            if (customer == null)
            {
                return this.NotFound();
            }

            CustomerDetailsViewModel model = await this.customerService.GetCustomerDetailsById(id);
            return this.View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            CustomerFormModel model = await this.customerService.GetCustomerForEditAsync(id);
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CustomerFormModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            try
            {
                await this.customerService.EditCustomerAsync(model);
                this.TempData[Message] = CustomerDetailsAmended;
                return this.RedirectToAction(nameof(this.Details), new { id = model.Id });
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, InvalidClientDetails);

                this.TempData[Message] = ex.Message;
                return this.View(model);
            }
        }

        [Authorize(Roles = ManagerRoleName + ", " + AdministratorRoleName)]
        public async Task<IActionResult> Delete(string id)
        {
            await this.customerService.DeleteCustomerAsync(id);
            return this.RedirectToAction("Index", "Dashboard", new { area = "Administration" });
        }
    }
}
