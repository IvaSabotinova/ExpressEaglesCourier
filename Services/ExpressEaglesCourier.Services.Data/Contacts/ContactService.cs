namespace ExpressEaglesCourier.Services.Data.Contacts
{
    using System.Text;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Services.Messaging;
    using ExpressEaglesCourier.Web.ViewModels.Contacts;

    public class ContactService : IContactService
    {
        private readonly IEmailSender emailSender;

        public ContactService(IEmailSender emailSender)
        {
            this.emailSender = emailSender;
        }

        public async Task OrderCourierByEmail(OrderCourierFormModel model)
        {
            StringBuilder html = new StringBuilder();
            html.AppendLine($"<h3>Client name: {model.FirstAndLastName}</h3>");
            html.AppendLine($"<p><u><b>Client details:</b></u></p>");
            html.AppendLine($"<p><u>Phone number</u>: {model.PhoneNumber}</p>");
            html.AppendLine($"<p><u>Email</u>: {model.Email}</p>");
            html.AppendLine($"<p><u>Address</u>: {model.PickUpAddress}, {model.PickUpCity}</p>");
            html.AppendLine($"<p><u>Type Of Shipment</u>: {model.ShipmentType}</p>");
            html.AppendLine($"<p><u>Additional Information</u>: {model.AdditionalInformation}</p>");
            html.AppendLine($"<p><u>Pick-up time</u> from {model.StartTime} to {model.EndTime}</p>");
            await this.emailSender.SendEmailAsync("ivasabotinova@students.softuni.bg", model.FirstAndLastName, "aziva@yahoo.com", "Order A Courier", html.ToString());
        }
    }
}
