namespace ExpressEaglesCourier.Web.Controllers
{
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Web.ViewModels;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using static ExpressEaglesCourier.Common.GlobalConstants.ViewModelConstants;

    using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

    public class UserController : Controller
    {
            private readonly UserManager<ApplicationUser> userManager;
            private readonly SignInManager<ApplicationUser> signInManager;

            public UserController(
                UserManager<ApplicationUser> userManager,
                SignInManager<ApplicationUser> signInManager)
            {
                this.userManager = userManager;
                this.signInManager = signInManager;
            }

            [HttpGet]
            public IActionResult Register()
            {
                RegisterViewModel registerViewModel = new RegisterViewModel();
                return this.View(registerViewModel);
            }

            [HttpPost]
            public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
            {
                if (!this.ModelState.IsValid)
                {
                    return this.View(registerViewModel);
                }

                ApplicationUser user = new ApplicationUser()
                {
                    UserName = registerViewModel.UserName,
                    Email = registerViewModel.Email,
                };
                IdentityResult result = await this.userManager.CreateAsync(user, registerViewModel.Password);

                if (result.Succeeded)
                {
                    return this.RedirectToAction(nameof(this.Login));
                }

                foreach (IdentityError error in result.Errors)
                {
                    this.ModelState.AddModelError(string.Empty, error.Description);
                }

                return this.View(registerViewModel);
            }

            [HttpGet]
            public IActionResult Login()
            {
                LoginViewModel loginViewModel = new LoginViewModel();
                return this.View(loginViewModel);
            }

            [HttpPost]
            public async Task<IActionResult> Login(LoginViewModel loginViewModel)
            {
                if (!this.ModelState.IsValid)
                {
                    return this.View(loginViewModel);
                }

                ApplicationUser user = await this.userManager.FindByNameAsync(loginViewModel.UserName);

                if (user != null)
                {
                    SignInResult result = await this.signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                    if (result.Succeeded)
                    {
                        return this.RedirectToAction("All", "Movies");
                    }
                }

                this.ModelState.AddModelError(string.Empty, UserErrorMessage);
                return this.View(loginViewModel);
            }

            [HttpPost]

            public async Task<IActionResult> Logout()
            {
                await this.signInManager.SignOutAsync();
                return this.RedirectToAction("Index", "Home");
            }
        }
}
