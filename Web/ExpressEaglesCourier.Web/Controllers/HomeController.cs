namespace ExpressEaglesCourier.Web.Controllers
{
    using System.Diagnostics;

    using ExpressEaglesCourier.Web.ViewModels;

    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        public IActionResult Temp()
        {
            return this.View();
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        public IActionResult FindUs()
        {
            return this.View();
        }

        public IActionResult AboutUs()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        // public IActionResult Error()
        // {
        //    return this.View(
        //        new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        // }
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 404)
            {
                return this.View("Error404");
            }
            else
            {
                return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
            }
        }
    }
}
