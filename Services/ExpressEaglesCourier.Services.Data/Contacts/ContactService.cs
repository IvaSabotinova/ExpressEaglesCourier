namespace ExpressEaglesCourier.Services.Data.Contacts
{
    using System.Text;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Services.Messaging;
    using ExpressEaglesCourier.Web.ViewModels.Contacts;
    using Ganss.Xss;

    public class ContactService : IContactService
    {
        private readonly IEmailSender emailSender;
        private readonly HtmlSanitizer sanitizer = new HtmlSanitizer();

        public ContactService(IEmailSender emailSender)
        {
            this.emailSender = emailSender;
        }

        public async Task OrderCourierByEmail(OrderCourierFormModel model)
        {
            StringBuilder html = new StringBuilder();
            html.AppendLine($"<h3>Client name: {this.sanitizer.Sanitize(model.FirstAndLastName)}</h3>");
            html.AppendLine($"<p><u><b>Client details:</b></u></p>");
            html.AppendLine($"<p><u>Phone number</u>: {this.sanitizer.Sanitize(model.PhoneNumber)}</p>");
            html.AppendLine($"<p><u>Email</u>: {this.sanitizer.Sanitize(model.Email)}</p>");
            html.AppendLine($"<p><u>Address</u>: {this.sanitizer.Sanitize(model.PickUpAddress)}, {this.sanitizer.Sanitize(model.PickUpCity)}</p>");
            html.AppendLine($"<p><u>Type Of Shipment</u>: {model.ShipmentType}</p>");
            html.AppendLine($"<p><u>Additional Information</u>: {this.sanitizer.Sanitize(model.AdditionalInformation)}</p>");
            html.AppendLine($"<p><u>Pick-up time</u> from {model.StartTime} to {model.EndTime}</p>");
            await this.emailSender.SendEmailAsync("ivasabotinova@students.softuni.bg", this.sanitizer.Sanitize(model.FirstAndLastName), "aziva@yahoo.com", "Order A Courier", html.ToString());
        }
    }
}
