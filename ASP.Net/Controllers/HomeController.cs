using ASP.Net.Helpers;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsRepository productRepository;

        public HomeController(IProductsRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public IActionResult Index()
        {
            var products = productRepository.GetAll();

            return View(products.ToProductViewModels());
        }
    }
}