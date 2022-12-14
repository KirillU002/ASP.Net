using ASP.Net.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApplication;

namespace ASP.Net.Areas.Admin.Controllers;

[Area ("Admin")]
public class RoleController : Controller
{
    private readonly IRolesRepository rolesRepository;

    public RoleController(IRolesRepository rolesRepository)
    {
        this.rolesRepository = rolesRepository;
    }

    public ActionResult Index()
    {
        var roles = rolesRepository.GetAll();
        return View(roles);
    }

    public ActionResult Remove(string roleName)
    {
        rolesRepository.Remove(roleName);
        return RedirectToAction(nameof(Index));
    }

    public ActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Add(Role role)
    {
        if (rolesRepository.TryGetByName(role.Name) != null)
        {
            ModelState.AddModelError("", "Такая роль уже существует");
        }
        if (ModelState.IsValid)
        {
            rolesRepository.Add(role);
            return RedirectToAction(nameof(Index));
        }
        return View(role);
    }
}
