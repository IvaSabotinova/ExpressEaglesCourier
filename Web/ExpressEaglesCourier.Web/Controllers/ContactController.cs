namespace ExpressEaglesCourier.Web.Controllers
{
    using System.Text;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Services.Messaging;
    using ExpressEaglesCourier.Web.ViewModels.Contacts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class ContactController : BaseController
    {
        private readonly IEmailSender emailSender;

        public ContactController(IEmailSender emailSender)
        {
            this.emailSender = emailSender;
        }

        [HttpGet]
        public IActionResult OrderCourierByEmail()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> OrderCourierByEmail(OrderCourierFormModel model)
        {
            StringBuilder html = new StringBuilder();
            html.AppendLine($"<h3>Client name: {model.FirstAndLastName}</h3>");
            html.AppendLine($"<h4><u>Client details:</u></h4>");
            html.AppendLine($"<h5>Phone number: {model.PhoneNumber}</h5>");
            html.AppendLine($"<h5>Email: {model.Email}</h5>");
            html.AppendLine($"<h5>Address: {model.PickUpAddress} {model.PickUpCity}</h5>");
            html.AppendLine($"<h5>Pick-up time from {model.StartTime} to {model.EndTime}</h5>");
            await this.emailSender.SendEmailAsync(model.Email, model.FirstAndLastName, "aziva@yahoo.com", "Order A Courier", html.ToString());

            return this.RedirectToAction("Index", "Home");
        }
    }
}
