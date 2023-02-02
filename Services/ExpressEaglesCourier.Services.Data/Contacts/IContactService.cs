namespace ExpressEaglesCourier.Services.Data.Contacts
{
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Web.ViewModels.Contacts;

    public interface IContactService
    {
        Task OrderCourierByEmail(OrderCourierFormModel model);
    }
}
