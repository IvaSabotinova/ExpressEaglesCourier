namespace ExpressEaglesCourier.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data;
    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Services.Data.Feedbacks;
    using ExpressEaglesCourier.Web.ViewModels.Feedbacks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    public class FeedbackController : AdministrationController
    {
        private readonly IFeedbackService feedbackService;
        private readonly ApplicationDbContext context;

        public FeedbackController(IFeedbackService feedbackService, ApplicationDbContext context)
        {
            this.feedbackService = feedbackService;
            this.context = context;
        }

        // TO AMEND
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

        // TO AMEND
        // GET: Administration/Feedback/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || this.context.Feedbacks == null)
            {
                return this.NotFound();
            }

            var feedback = await this.context.Feedbacks.FindAsync(id);
            if (feedback == null)
            {
                return this.NotFound();
            }

            this.ViewData["ApplicationUserId"] = new SelectList(this.context.Users, "Id", "Id", feedback.ApplicationUserId);
            this.ViewData["ShipmentId"] = new SelectList(this.context.Shipments, "Id", "DestinationAddress", feedback.ShipmentId);
            return this.View(feedback);
        }

        // TO AMEND
        // POST: Administration/Feedback/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Content,FeedbackType,ShipmentId,ApplicationUserId,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Feedback feedback)
        {
            if (id != feedback.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.context.Update(feedback);
                    await this.context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.FeedbackExists(feedback.Id))
                    {
                        return this.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return this.RedirectToAction(nameof(this.All));
            }

            this.ViewData["ApplicationUserId"] = new SelectList(this.context.Users, "Id", "Id", feedback.ApplicationUserId);
            this.ViewData["ShipmentId"] = new SelectList(this.context.Shipments, "Id", "DestinationAddress", feedback.ShipmentId);
            return this.View(feedback);
        }

        // TO AMEND
        // GET: Administration/Feedback
        public async Task<IActionResult> All()
        {
            var applicationDbContext = this.context.Feedbacks.Include(f => f.ApplicationUser).Include(f => f.Shipment);
            return this.View(await applicationDbContext.ToListAsync());
        }

        // TO AMEND
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

        // TO AMEND
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
