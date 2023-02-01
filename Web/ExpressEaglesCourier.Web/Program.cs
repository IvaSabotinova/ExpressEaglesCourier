namespace ExpressEaglesCourier.Web
{
    using System.Reflection;

    using ExpressEaglesCourier.Data;
    using ExpressEaglesCourier.Data.Common;
    using ExpressEaglesCourier.Data.Common.Repositories;
    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Data.Repositories;
    using ExpressEaglesCourier.Data.Seeding;
    using ExpressEaglesCourier.Services.Data.Customers;
    using ExpressEaglesCourier.Services.Data.Employees;
    using ExpressEaglesCourier.Services.Data.Feedbacks;
    using ExpressEaglesCourier.Services.Data.Searches;
    using ExpressEaglesCourier.Services.Data.ShipmentImages;
    using ExpressEaglesCourier.Services.Data.Shipments;
    using ExpressEaglesCourier.Services.Data.ShipmentTrackingPaths;
    using ExpressEaglesCourier.Services.Data.Stats;
    using ExpressEaglesCourier.Services.Mapping;
    using ExpressEaglesCourier.Services.Messaging;
    using ExpressEaglesCourier.Web.Infrastructure.ModelBinders;
    using ExpressEaglesCourier.Web.ViewModels;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder.Services, builder.Configuration);
            var app = builder.Build();
            Configure(app);
            app.Run();
        }

        private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<ApplicationUser>(IdentityOptionsProvider.GetIdentityOptions)
                .AddRoles<ApplicationRole>().AddEntityFrameworkStores<ApplicationDbContext>();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/User/Login";
            });

            services.Configure<CookiePolicyOptions>(
                options =>
                {
                    options.CheckConsentNeeded = context => true;
                    options.MinimumSameSitePolicy = SameSiteMode.None;
                });

            services.AddControllersWithViews(
                options =>
                {
                      options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
                })
                .AddRazorRuntimeCompilation()
                .AddMvcOptions(options =>
                {
                    options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
                    options.ModelBinderProviders.Insert(1, new DoubleModelBinderProvider());
                });

            services.AddRazorPages();
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddSingleton(configuration);

            // Data repositories
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IDbQueryRunner, DbQueryRunner>();

            // Application services
            // services.AddTransient<IEmailSender, NullMessageSender>();

            services.AddTransient<IEmailSender>(x => new SendGridEmailSender(configuration["SendGrid:ApiKey"]));
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IShipmentService, ShipmentService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IShipmentTrackingPathService, ShipmentTrackingPathService>();
            services.AddTransient<IStatsService, StatsService>();
            services.AddTransient<ISearchService, SearchService>();
            services.AddTransient<IShipmentImageService, ShipmentImageService>();
            services.AddTransient<IFeedbackService, FeedbackService>();
        }

        private static void Configure(WebApplication app)
        {
            // Seed data on application startup
            using (var serviceScope = app.Services.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.Migrate();
                new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
            }

            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute("areaRoute", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();
        }
    }
}
