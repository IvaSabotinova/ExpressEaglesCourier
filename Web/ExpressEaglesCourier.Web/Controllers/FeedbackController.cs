namespace ExpressEaglesCourier.Web.Controllers
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Services.Data.Feedbacks;
    using ExpressEaglesCourier.Web.ViewModels.Feedbacks;
    using Microsoft.AspNetCore.Mvc;

    using static ExpressEaglesCourier.Common.GlobalConstants.ServicesConstants;

    public class FeedbackController : BaseController
    {
        private readonly IFeedbackService feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            this.feedbackService = feedbackService;
        }

        public IActionResult Create()
        {
            FeedbackCreateModel model = new FeedbackCreateModel();
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(FeedbackCreateModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            try
            {
                await this.feedbackService.CreateAsync(userId, model);
                this.TempData[Message] = FeedbackSuccessfullySent;
                return this.RedirectToAction("Index", "Home", new { area = string.Empty });
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, SmthWentWrong);

                this.TempData[Message] = ex.Message;
                return this.View(model);
            }
        }
    }
}
