using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApplication.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Orders()
        {
            return View();
        }

        public ActionResult Users()
        {
            return View();
        }
        public ActionResult Roles()
        {
            return View();
        }
        public ActionResult Products()
        {
            return View();
        }
    }
}
