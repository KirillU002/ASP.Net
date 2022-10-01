using ASP.Net.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Net.Areas.Admin.Controllers;

[Area ("Admin")]
public class UserController : Controller
{
    private readonly IUsersManager usersManager;

    public UserController(IUsersManager usersManager)
    {
        this.usersManager = usersManager;
    }

    public ActionResult Index()
    {
        var userAccount = usersManager.GetAll();
        return View(userAccount);
    }

    public ActionResult Detail(string name)
    {
        var userAccount = usersManager.TryGetByName(name);
        return View(userAccount);
    }

    public ActionResult ChangePassword(string name)
    {        
        var changePassword = new ChangePassword()
        {
            UserName = name
        };
        return View(name);
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
            usersManager.ChangePassword(changePassword.UserName, changePassword.Password);

            return RedirectToAction(nameof(Index));
        }
        else
            return RedirectToAction(nameof(ChangePassword));
    }
}
