namespace ExpressEaglesCourier.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data;
    using ExpressEaglesCourier.Services.Data.Feedbacks;
    using ExpressEaglesCourier.Web.ViewModels.Feedbacks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using static ExpressEaglesCourier.Common.GlobalConstants.ServicesConstants;

    public class FeedbackController : AdministrationController
    {
        private readonly IFeedbackService feedbackService;
        private readonly ApplicationDbContext context;

        public FeedbackController(IFeedbackService feedbackService, ApplicationDbContext context)
        {
            this.feedbackService = feedbackService;
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id < 1)
            {
                return this.NotFound();
            }

            FeedbackEditModel model = await this.feedbackService.GetById<FeedbackEditModel>(id);

            return this.View(model);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(FeedbackEditModel model)
        {
            if (model.Id < 1)
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
                return this.RedirectToAction(nameof(this.All));
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, InvalidFeedback);
                this.TempData[Message] = ex.Message;
                return this.View(model);
            }
        }


        // PENDING AMENDMENT
        // GET: Administration/Feedback/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || this.context.Feedbacks == null)
            {
                return this.NotFound();
            }

            var feedback = await this.context.Feedbacks
                .Include(f => f.ApplicationUser)
                .Include(f => f.Shipment)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (feedback == null)
            {
                return this.NotFound();
            }

            return this.View(feedback);
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<FeedbackAllViewModel> model = await this.feedbackService.GetAll<FeedbackAllViewModel>();
            return this.View(model);
        }

        // PENDING AMENDMENT
        // GET: Administration/Feedback/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || this.context.Feedbacks == null)
            {
                return this.NotFound();
            }

            var feedback = await this.context.Feedbacks
                .Include(f => f.ApplicationUser)
                .Include(f => f.Shipment)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (feedback == null)
            {
                return this.NotFound();
            }

            return this.View(feedback);
        }

        // PENDING AMENDMENT
        // POST: Administration/Feedback/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (this.context.Feedbacks == null)
            {
                return this.Problem("Entity set 'ApplicationDbContext.Feedbacks'  is null.");
            }

            var feedback = await this.context.Feedbacks.FindAsync(id);
            if (feedback != null)
            {
                this.context.Feedbacks.Remove(feedback);
            }

            await this.context.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.All));
        }

        private bool FeedbackExists(int id)
        {
            return this.context.Feedbacks.Any(e => e.Id == id);
        }
    }
}
