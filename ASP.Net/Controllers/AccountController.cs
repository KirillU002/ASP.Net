using ASP.Net;
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
        private readonly IUsersManager usersManager;
        private readonly UserManager<User> _usersManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(IUsersManager usersManager, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.usersManager = usersManager;
            _usersManager = userManager;
            _signInManager = signInManager;
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
                var result = _signInManager.PasswordSignInAsync(login.UserName, login.Password, login.RememberMe, false).Result;

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

                var result = _usersManager.CreateAsync(user, register.Password).Result;
                if (result.Succeeded)
                {
                    _signInManager.SignInAsync(user, false).Wait();

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
            //if(register.UserName == register.Password)
            //{
            //    ModelState.AddModelError("", "Логин и пароль не должны совпадать");
            //}

            //if (ModelState.IsValid)
            //{
            //    usersManager.Add(new UserAccount
            //    {
            //        Name = register.UserName,
            //        Phone = register.Phone,
            //        Password = register.Password
            //    });
            //    return RedirectToAction(nameof(HomeController.Index), "Home");
            //}
            //else
            //    return RedirectToAction(nameof(Register));
        }

        private void TryAssignUserRole(User user)
        {
            try
            {
                _usersManager.AddToRoleAsync(user, Constants.UserRoleName).Wait();
            }
            catch
            {
                //log
            }
        }

        public IActionResult Logout()
        {
            _signInManager.SignOutAsync().Wait();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
