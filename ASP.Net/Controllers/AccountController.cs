using ASP.Net;
using ASP.Net.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsersManager usersManager;

        public AccountController(IUsersManager usersManager)
        {
            this.usersManager = usersManager;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(Login));

              var userAccount = usersManager.TryGetByName(login.UserName);
                if(userAccount == null)
                {
                    ModelState.AddModelError("", "Такого пользователя не существует");
                    return RedirectToAction(nameof(Login));
                }

                if(userAccount.Password != login.Password)
                {
                    ModelState.AddModelError("", "Неправильный пароль");
                    return RedirectToAction(nameof(Login));
                }

                    return RedirectToAction(nameof(HomeController.Index), nameof(HomeController));            
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Register register)
        {
            if(register.UserName == register.Password)
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать");
            }

            if (ModelState.IsValid)
            {
                usersManager.Add(new UserAccount
                {
                    Name = register.UserName,
                    Phone = register.Phone,
                    Password = register.Password
                });
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            else
                return RedirectToAction(nameof(Register));
        }
    }
}
