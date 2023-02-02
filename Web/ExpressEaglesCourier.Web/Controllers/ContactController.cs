namespace ExpressEaglesCourier.Web.Controllers
{
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Services.Data.Contacts;
    using ExpressEaglesCourier.Web.ViewModels.Contacts;
    using Microsoft.AspNetCore.Mvc;

    public class ContactController : BaseController
    {
        private readonly IContactService contactService;

        public ContactController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        [HttpGet]
        public IActionResult OrderCourierByEmail()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> OrderCourierByEmail(OrderCourierFormModel model)
        {
            await this.contactService.OrderCourierByEmail(model);

            return this.RedirectToAction("Index", "Home");
        }
    }
}
