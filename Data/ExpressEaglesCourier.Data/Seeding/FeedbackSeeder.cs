namespace ExpressEaglesCourier.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Data.Models.Enums;
    using Microsoft.EntityFrameworkCore;

    public class FeedbackSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (await dbContext.Feedbacks.AnyAsync())
            {
                return;
            }

            Customer customer1 = await dbContext.Customers
                .FirstOrDefaultAsync(x => x.PhoneNumber == "00359877111111");
            Customer customer2 = await dbContext.Customers
                .FirstOrDefaultAsync(x => x.PhoneNumber == "00359877334334");
            Customer customer3 = await dbContext.Customers
                .FirstOrDefaultAsync(x => x.PhoneNumber == "00359877222222");
            Customer customer4 = await dbContext.Customers
                .FirstOrDefaultAsync(x => x.PhoneNumber == "00359898554554");
            Customer customer5 = await dbContext.Customers
                .FirstOrDefaultAsync(x => x.PhoneNumber == "00359899555555");
            Customer customer6 = await dbContext.Customers
                .FirstOrDefaultAsync(x => x.PhoneNumber == "00359888556556");

            List<Feedback> feedbacks = new List<Feedback>()
            {
                new Feedback()
                {
                    Title = "Awesome Service",
                    SenderName = "Rayko",
                    Content = "In a matter of hours, I received an offer that matched my budget from a company with very good feedback. I love being able to rely on EEC for getting the precious finds across the country for a reasonable price.",
                    ShipmentId = 1,
                    ApplicationUserId = customer1.ApplicationUserId,
                    FeedbackType = FeedbackType.Positive,
                },
                new Feedback()
                {
                    Title = "Thankful",
                    SenderName = "Zdravko",
                    Content = "EEC fills the gaps between getting bulky items collected and delivered and you having to go get them yourself. Used them many times, saves me lots of time and money.",
                    ApplicationUserId = customer2.ApplicationUserId,
                    FeedbackType = FeedbackType.Positive,
                },
                new Feedback()
                {
                    Title = "Fantastic Service",
                    SenderName = "Your Client",
                    Content = "All went very smoothly and easily and the courier whose bid I accepted were lovely, good communication, and helpful. Couldn't fault at all and would certainly use again.",
                    ApplicationUserId = customer3.ApplicationUserId,
                    FeedbackType = FeedbackType.Positive,
                },
                new Feedback()
                {
                    Title = "Good service!",
                    SenderName = "One of your clients",
                    Content = "Simple and effective, will be using regularly. Good value and makes the process of moving big things around so much easier!",
                    ApplicationUserId = customer4.ApplicationUserId,
                    FeedbackType = FeedbackType.Positive,
                },
                new Feedback()
                {
                    Title = "Awesome Service",
                    SenderName = "Some sender",
                    Content = "In a matter of hours, I received an offer that matched my budget from a company with very good feedback. I love being able to rely on EEC for getting the precious finds across the country for a reasonable price.",
                    ApplicationUserId = customer5.ApplicationUserId,
                    FeedbackType = FeedbackType.Positive,
                },
                new Feedback()
                {
                    Title = "Thankful",
                    SenderName = "A client",
                    Content = "EEC fills the gaps between getting bulky items collected and delivered and you having to go get them yourself. Used them many times, saves me lots of time and money.",
                    ApplicationUserId = customer6.ApplicationUserId,
                    FeedbackType = FeedbackType.Positive,
                },
                new Feedback()
                {
                    Title = "Fantastic Service",
                    SenderName = "Your Client",
                    Content = "All went very smoothly and easily and the courier whose bid I accepted were lovely, good communication, and helpful. Couldn't fault at all and would certainly use again.",
                    ApplicationUserId = customer1.ApplicationUserId,
                    FeedbackType = FeedbackType.Positive,
                },
                new Feedback()
                {
                    Title = "Good service!",
                    SenderName = "One of your clients",
                    Content = "Simple and effective, will be using regularly. Good value and makes the process of moving big things around so much easier!",
                    ApplicationUserId = customer2.ApplicationUserId,
                    FeedbackType = FeedbackType.Positive,
                },
                new Feedback()
                {
                    Title = "Awesome Service",
                    Content = "In a matter of hours, I received an offer that matched my budget from a company with very good feedback. I love being able to rely on EEC for getting the precious finds across the country for a reasonable price.",
                    ApplicationUserId = customer3.ApplicationUserId,
                    FeedbackType = FeedbackType.Positive,
                },
                new Feedback()
                {
                    Title = "Thankful",
                    Content = "EEC fills the gaps between getting bulky items collected and delivered and you having to go get them yourself. Used them many times, saves me lots of time and money.",
                    ApplicationUserId = customer4.ApplicationUserId,
                    FeedbackType = FeedbackType.Positive,
                },
                new Feedback()
                {
                    Title = "Fantastic Service",
                    SenderName = "Your Client",
                    Content = "All went very smoothly and easily and the courier whose bid I accepted were lovely, good communication, and helpful. Couldn't fault at all and would certainly use again.",
                    ApplicationUserId = customer5.ApplicationUserId,
                    FeedbackType = FeedbackType.Positive,
                },
                new Feedback()
                {
                    Title = "Good service!",
                    SenderName = "One of your clients",
                    Content = "Simple and effective, will be using regularly. Good value and makes the process of moving big things around so much easier!",
                    ApplicationUserId = customer6.ApplicationUserId,
                    FeedbackType = FeedbackType.Positive,
                },
                new Feedback()
                {
                    Title = "Not Happy",
                    SenderName = "Anonymous",
                    Content = "EEC delayed my shipment.",
                    ApplicationUserId = customer3.ApplicationUserId,
                    FeedbackType = FeedbackType.Negative,
                },
                new Feedback()
                {
                    Title = "Thankful",
                    Content = "EEC fills the gaps between getting bulky items collected and delivered and you having to go get them yourself. Used them many times, saves me lots of time and money.",
                    ApplicationUserId = customer1.ApplicationUserId,
                    FeedbackType = FeedbackType.Positive,
                },
                new Feedback()
                {
                    Title = "Your Service",
                    SenderName = "Anonymous",
                    Content = "Please be more flexible for urgent shipments!!",
                    ApplicationUserId = customer3.ApplicationUserId,
                    FeedbackType = FeedbackType.Negative,
                },
                new Feedback()
                {
                    Title = "Good service!",
                    SenderName = "One of your clients",
                    Content = "Simple and effective, will be using regularly. Good value and makes the process of moving big things around so much easier!",
                    ApplicationUserId = customer2.ApplicationUserId,
                    FeedbackType = FeedbackType.Positive,
                },
                new Feedback()
                {
                    Title = "Awesome Service",
                    Content = "In a matter of hours, I received an offer that matched my budget from a company with very good feedback. I love being able to rely on EEC for getting the precious finds across the country for a reasonable price.",
                    ApplicationUserId = customer5.ApplicationUserId,
                    FeedbackType = FeedbackType.Positive,
                },
                new Feedback()
                {
                    Title = "Thankful",
                    Content = "EEC fills the gaps between getting bulky items collected and delivered and you having to go get them yourself. Used them many times, saves me lots of time and money.",
                    ApplicationUserId = customer6.ApplicationUserId,
                    FeedbackType = FeedbackType.Positive,
                },
                new Feedback()
                {
                    Title = "Good service!",
                    SenderName = "One of your clients",
                    Content = "Simple and effective, will be using regularly. Good value and makes the process of moving big things around so much easier!",
                    ApplicationUserId = customer4.ApplicationUserId,
                    FeedbackType = FeedbackType.Positive,
                },
                new Feedback()
                {
                    Title = "Just like that",
                    SenderName = "Regular Client",
                    Content = "Your staff is doing great but you should consider opening another office and employ more people to help things move faster!",
                    ApplicationUserId = customer6.ApplicationUserId,
                    FeedbackType = FeedbackType.Recommendation,
                },
            };

            await dbContext.Feedbacks.AddRangeAsync(feedbacks);
        }
    }
}
