using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApplication.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductsRepository productRepository;

        public AdminController(IProductsRepository productRepository)
        {
            this.productRepository = productRepository;
        }

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
            var products = productRepository.GetAllMonitors();
            return View(products);
        }
    }
}
