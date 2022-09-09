using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApplication.Models;

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

        public IActionResult AddProduct()
        {
            return View();
        }

        public IProductsRepository GetProductRepository()
        {
            return productRepository;
        }

        [HttpPost]
        public ActionResult AddProduct(MonitorsProduct product)
        {
            if (ModelState.IsValid)
            {
                return View(product);
            }

            productRepository.Add(product);
            return RedirectToAction("Products");
        }

        public IActionResult EditProduct(int productId)
        {
            var product = productRepository.TryGetByIdMonitors(productId);
            return View(product);
        }

        [HttpPost]
        public ActionResult EditProduct(MonitorsProduct product)
        {
            if (ModelState.IsValid)
            {
                return View(product);
            }

            productRepository.Update(product);
            return RedirectToAction("Products");
        }
    }
}
