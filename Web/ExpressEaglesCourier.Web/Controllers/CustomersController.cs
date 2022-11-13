namespace ExpressEaglesCourier.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Services.Data.Customers;
    using ExpressEaglesCourier.Web.ViewModels.Customers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static ExpressEaglesCourier.Common.GlobalConstants.ServicesConstants;

    [Authorize]
    public class CustomersController : BaseController
    {
        private readonly ICustomerService customerService;

        public CustomersController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Add()
        {
            AddNewCustomerModel newCustomerModel = new AddNewCustomerModel();

            return this.View(newCustomerModel);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Add(AddNewCustomerModel newCustomerModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(newCustomerModel);
            }

            try
            {
                await this.customerService.CreateCustomerAsync(newCustomerModel);
                return this.RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, InvalidClientDetails);
                return this.View(newCustomerModel);
            }
        }

        [HttpGet]
        [AllowAnonymous]

        public async Task<IActionResult> Edit(string customerId)
        {
            EditCustomerModel editCustomerModel = await this.customerService.GetCustomerForEditAsync(customerId);

            return this.View(editCustomerModel);
        }

        [HttpPost]
        [AllowAnonymous]

        public async Task<IActionResult> Edit(EditCustomerModel editCustomerModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(editCustomerModel);
            }

            await this.customerService.EditCustomerAsync(editCustomerModel);
            return this.RedirectToAction("Index", "Home");
        }
    }
}
