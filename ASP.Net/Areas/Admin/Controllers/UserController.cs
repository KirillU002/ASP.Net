using Microsoft.AspNetCore.Mvc;

namespace ASP.Net.Areas.Admin.Controllers;

[Area ("Admin")]
public class UserController : Controller
{
    public ActionResult Index()
    {
        return View();
    }
}
