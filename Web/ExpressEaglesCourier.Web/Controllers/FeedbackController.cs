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

            // ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id");
            // ViewData["ShipmentId"] = new SelectList(_context.Shipments, "Id", "DestinationAddress");
            // return View();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        // public async Task<IActionResult> Create([Bind("Content,FeedbackType,ShipmentId,ApplicationUserId,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Feedback feedback)
        // {
        //    if (this.ModelState.IsValid)
        //    {
        //        this.context.Add(feedback);
        //        await this.context.SaveChangesAsync();
        //        return this.RedirectToAction(nameof(this.All));
        //    }

        // this.ViewData["ApplicationUserId"] = new SelectList(this.context.Users, "Id", "Id", feedback.ApplicationUserId);
        //    this.ViewData["ShipmentId"] = new SelectList(this.context.Shipments, "Id", "DestinationAddress", feedback.ShipmentId);
        //    return this.View(feedback);
        // }
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
