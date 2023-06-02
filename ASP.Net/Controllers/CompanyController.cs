using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Net.Controllers
{
    public class CompanyController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
