namespace ExpressEaglesCourier.Web.Areas.Administration.Controllers
{
    using System;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Services.Data.Customers;
    using ExpressEaglesCourier.Web.Controllers;
    using ExpressEaglesCourier.Web.ViewModels.Customers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static ExpressEaglesCourier.Common.GlobalConstants.ServicesConstants;

    [Authorize]
    [Area("Administration")]
    public class CustomerController : BaseController
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Add()
        {
            CustomerFormModel model = new CustomerFormModel();

            return this.View(model);
        }

        [AllowAnonymous]
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
        [AllowAnonymous]
        public async Task<IActionResult> Details([FromRoute] string id)
        {
            CustomerDetailsViewModel model = await this.customerService.GetCustomerDetailsById(id);

            return this.View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Edit(string id)
        {
            CustomerFormModel model = await this.customerService.GetCustomerForEditAsync(id);
            return this.View(model);
        }

        [HttpPost]
        [AllowAnonymous]
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

        [AllowAnonymous]
        public async Task<IActionResult> Delete(string id)
        {
              await this.customerService.DeleteCustomerAsync(id);
              return this.RedirectToAction("Index", "Home", new { area = string.Empty });
        }
    }
}
