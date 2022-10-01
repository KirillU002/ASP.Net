using ASP.Net.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApplication.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }
            else
                return RedirectToAction("Login");
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
                return RedirectToAction("Index", "Home");
            }
            else
                return RedirectToAction("Register");
        }
    }
}
