using ASP.Net.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using ASP.Net.Helpers;
using ASP.Net.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace ASP.Net.Areas.Admin.Controllers
{
	[Area(OnlineShop.Db.Constants.AdminRoleName)]
	[Authorize(Roles = OnlineShop.Db.Constants.AdminRoleName)]
	public class UserController : Controller
    {
        //private readonly IUsersManager usersManager;
        private readonly UserManager<User> usersManager;
        private readonly RoleManager<IdentityRole> rolesManager;

        public UserController(UserManager<User> usersManager, RoleManager<IdentityRole> rolesManager)
        {
            this.usersManager = usersManager;
            this.rolesManager = rolesManager;
        }

        public IActionResult Index()
        {
            //var userAccount = usersManager.GetAll();
            var userAccount = usersManager.Users.ToList();
            return View(userAccount.Select(x => x.ToUserViewModel()).ToList());
        }

        public IActionResult Detail(string name)
        {
            //var userAccount = usersManager.TryGetByName(name);
            var userAccount = usersManager.FindByNameAsync(name).Result;
            return View(userAccount.ToUserViewModel());
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
                var user = usersManager.FindByNameAsync(changePassword.UserName).Result;
                var newHahPassword = usersManager.PasswordHasher.HashPassword(user, changePassword.Password);
                user.PasswordHash = newHahPassword;

                usersManager.UpdateAsync(user).Wait();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(ChangePassword));

        //    if (ModelState.IsValid)
        //    {
        //        usersManager.ChangePassword(changePassword.UserName, changePassword.Password);

        //        return RedirectToAction(nameof(Index));
        //    }
        //    else
        //        return RedirectToAction(nameof(ChangePassword));
        }
        public IActionResult EditUser(string name)
        {
                //var editUser = usersManager.TryGetByName(name);
                var editUser = usersManager.FindByNameAsync(name).Result;
                return View(editUser);
        }

        //[HttpPost]
        //public IActionResult EditUser(UserViewModel user)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(user);
        //    }

        //    usersManager.Update(user);
        //    return RedirectToAction(nameof(Index));
        //}

        public IActionResult Delete(string name)
        {
            var user = usersManager.FindByNameAsync(name).Result;
            usersManager.DeleteAsync(user).Wait();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult EditRights(string name)
        {
            var user = usersManager.FindByNameAsync(name).Result;
            var userRoles = usersManager.GetRolesAsync(user).Result;
            var roles = rolesManager.Roles.ToList();
            var model = new EditRightsViewModel
            {
                UserName = user.UserName,
                UserRoles = userRoles.Select(x => new RoleViewModel { Name = x }).ToList(),
                AllRoles = roles.Select(x => new RoleViewModel { Name = x.Name }).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult EditRights(string name, Dictionary<string, string> userRolesViewModel)
        {
            var userSelectedRoles = userRolesViewModel.Select(x => x.Key);

			var user = usersManager.FindByNameAsync(name).Result;
			var userRoles = usersManager.GetRolesAsync(user).Result;

            usersManager.RemoveFromRolesAsync(user, userRoles).Wait();
            usersManager.AddToRolesAsync(user, userSelectedRoles).Wait();

			return Redirect($"/Admin/User/Detail?name={name}");
        }

	}
}