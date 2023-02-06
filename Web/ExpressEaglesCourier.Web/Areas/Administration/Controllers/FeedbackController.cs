namespace ExpressEaglesCourier.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Services.Data.Feedbacks;
    using ExpressEaglesCourier.Web.ViewModels.Feedbacks;
    using Microsoft.AspNetCore.Mvc;

    using static ExpressEaglesCourier.Common.GlobalConstants.ServicesConstants;

    public class FeedbackController : AdministrationController
    {
        private readonly IFeedbackService feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            this.feedbackService = feedbackService;
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (await this.feedbackService.GetFeedbackById(id) == null)
            {
                return this.NotFound();
            }

            FeedbackEditModel model = await this.feedbackService.GetById<FeedbackEditModel>(id);

            return this.View(model);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(FeedbackEditModel model)
        {
            if (await this.feedbackService.GetFeedbackById(model.Id) == null)
            {
                return this.NotFound();
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            try
            {
                await this.feedbackService.EditAsync(model);
                this.TempData[Message] = FeedbackUpdated;
                return this.RedirectToAction(nameof(this.Details), new { model.Id });
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, InvalidFeedback);
                this.TempData[Message] = ex.Message;
                return this.View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details([FromRoute]int id)
        {
            if (await this.feedbackService.GetFeedbackById(id) == null)
            {
                return this.NotFound();
            }

            SingleFeedbackViewModel model = await this.feedbackService.GetById<SingleFeedbackViewModel>(id);

            return this.View(model);
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<FeedbackAllViewModel> model = await this.feedbackService.GetAll<FeedbackAllViewModel>();
            return this.View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (await this.feedbackService.GetFeedbackById(id) == null)
            {
                return this.NotFound();
            }

            FeedbackDeleteViewModel model = await this.feedbackService.GetById<FeedbackDeleteViewModel>(id);

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SoftDelete(int id)
        {
            if (await this.feedbackService.GetFeedbackById(id) == null)
            {
                return this.NotFound();
            }

            await this.feedbackService.SoftDeleteAsync(id);

            return this.RedirectToAction(nameof(this.All));
        }

        [HttpPost]
        public async Task<IActionResult> HardDelete(int id)
        {
            if (await this.feedbackService.GetFeedbackById(id) == null)
            {
                return this.NotFound();
            }

            await this.feedbackService.HardDeleteAsync(id);

            return this.RedirectToAction(nameof(this.All));
        }
    }
}
