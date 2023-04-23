using ASP.Net.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Net.Areas.Admin.Controllers
{
    [Area(OnlineShop.Db.Constants.AdminRoleName)]
    [Authorize(Roles = OnlineShop.Db.Constants.AdminRoleName)]
    public class UserController : Controller
    {
        private readonly IUsersManager usersManager;

        public UserController(IUsersManager usersManager)
        {
            this.usersManager = usersManager;
        }

        public IActionResult Index()
        {
            var userAccount = usersManager.GetAll();
            return View(userAccount);
        }

        public IActionResult Detail(string name)
        {
            var userAccount = usersManager.TryGetByName(name);
            return View(userAccount);
        }

        public IActionResult ChangePassword(string name)
        {
            var changePassword = new ChangePassword()
            {
                UserName = name
            };
            return View(changePassword);
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePassword changePassword)
        {
            if (changePassword.UserName == changePassword.Password)
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать");
            }

            if (ModelState.IsValid)
            {
                usersManager.ChangePassword(changePassword.UserName, changePassword.Password);

                return RedirectToAction(nameof(Index));
            }
            else
                return RedirectToAction(nameof(ChangePassword));
        }
        public IActionResult EditUser(string name)
        {
            var editUser = usersManager.TryGetByName(name);
            return View(editUser);
        }

        [HttpPost]
        public IActionResult EditUser(UserAccount user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            usersManager.Update(user);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(string name)
        {
            usersManager.Delete(name);
            return RedirectToAction(nameof(Index));
        }
    }
}