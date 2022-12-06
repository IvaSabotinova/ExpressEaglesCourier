namespace ExpressEaglesCourier.Web.Controllers
{
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Web.ViewModels;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using static ExpressEaglesCourier.Common.GlobalConstants;
    using static ExpressEaglesCourier.Common.GlobalConstants.ViewModelConstants;

    using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

    public class UserController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<ApplicationRole> roleManager;

        public UserController(
                UserManager<ApplicationUser> userManager,
                SignInManager<ApplicationUser> signInManager,
                RoleManager<ApplicationRole> roleManager)
        {
                this.userManager = userManager;
                this.signInManager = signInManager;
                this.roleManager = roleManager;
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

              ApplicationUser user = await this.userManager.FindByNameAsync(registerViewModel.UserName);

              IdentityResult result;

              if (user != null && (await this.userManager.IsInRoleAsync(user, ManagerRoleName)
                    || await this.userManager.IsInRoleAsync(user, EmployeeRoleName)))
              {
                    result = await this.userManager.AddPasswordAsync(user,  registerViewModel.Password);
              }
              else
              {
                    ApplicationUser newUser = new ApplicationUser()
                    {
                        UserName = registerViewModel.UserName,
                        Email = registerViewModel.Email,
                        PhoneNumber = registerViewModel.TelephoneNumber,
                    };
                    result = await this.userManager.CreateAsync(newUser, registerViewModel.Password);
              }

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
                     return this.RedirectToAction("Index", "Home");
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
