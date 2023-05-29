using ASP.Net;
using ASP.Net.Helpers;
using ASP.Net.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;

namespace OnlineShopWebApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> usersManager;
        private readonly SignInManager<User> signInManager;
        private readonly ILogger<AccountController> logger;
        private readonly Service service;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ILogger<AccountController> logger, Service service)
        {
            usersManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
            this.service = service;
        }

        public IActionResult Index(string name)
        {
            var userAccount = usersManager.FindByNameAsync(name).Result;
            return View(userAccount.ToUserViewModel());
        }

        public ActionResult Login(string returnUrl)
        {
            return View(new Login() {ReturnUrl = returnUrl});
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {
            if (!ModelState.IsValid)
            {
                var result = signInManager.PasswordSignInAsync(login.UserName, login.Password, login.RememberMe, false).Result;

                if (result.Succeeded)
                {
                    return Redirect(login.ReturnUrl ?? "/Home");
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный пароль");
                }
            }

            return View(login);           
        }

        public ActionResult Register(string returnUrl)
        {
            return View(new Register() { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public ActionResult Register(Register register)
        {
            if (register.UserName == register.Password)
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать");
            }

            if (!ModelState.IsValid)
            {
                User user = new User { Email = register.UserName, UserName = register.UserName, PhoneNumber = register.Phone };

                var result = usersManager.CreateAsync(user, register.Password).Result;
                if (result.Succeeded)
                {
                    service.SendEmailDefault(user.Email);
                    signInManager.SignInAsync(user, false).Wait();

                    TryAssignUserRole(user);
                    return Redirect(register.ReturnUrl ?? "/Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(register);
        }

        private void TryAssignUserRole(User user)
        {
            try
            {
                usersManager.AddToRoleAsync(user, Constants.UserRoleName).Wait();
            }
            catch
            {
                //log
            }
        }

        public IActionResult Logout()
        {
            signInManager.SignOutAsync().Wait();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

		public ActionResult ChangePassword(string name)
		{
			var changePassword = new ChangePassword()
			{
				UserName = name
			};
			return View(changePassword);
		}

        [HttpPost]
        public ActionResult ChangePassword(ChangePassword changePassword)
        {
            if (changePassword.UserName == changePassword.Password)
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать");
            }

            if (ModelState.IsValid)
            {
                var user = usersManager.FindByNameAsync(changePassword.UserName).Result;
                var newHahPassword = usersManager.PasswordHasher.HashPassword(user, changePassword.Password);
                user.PasswordHash = newHahPassword;

                usersManager.UpdateAsync(user).Wait();
                return RedirectToAction(nameof(HomeController.Index));
            }
			return RedirectToAction(nameof(ChangePassword));
        }
	}
}
