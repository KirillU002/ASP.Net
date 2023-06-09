using ASP.Net.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApplication;
using System.Data;

namespace ASP.Net.Areas.Admin.Controllers
{
    [Area(OnlineShop.Db.Constants.AdminRoleName)]
    [Authorize(Roles = OnlineShop.Db.Constants.AdminRoleName)]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> rolesManager;

        public RoleController(RoleManager<IdentityRole> rolesRepository)
        {
            this.rolesManager = rolesRepository;
        }

        public ActionResult Index()
        {
            var roles = rolesManager.Roles.ToList();
            return View(roles.Select(x => new RoleViewModel { Name = x.Name}).ToList());
        }

        public ActionResult Remove(string roleName)
        {
            var role = rolesManager.FindByNameAsync(roleName).Result;
            if(role != null)
            {
                rolesManager.DeleteAsync(role).Wait();
            }
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(RoleViewModel role)
        {
            var result = rolesManager.CreateAsync(new IdentityRole(role.Name)).Result;
            if(result.Succeeded) 
            { 
                return RedirectToAction(nameof(Index));
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(role);
        }
    }
}