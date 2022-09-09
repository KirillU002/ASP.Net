using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApplication.Models;
using System.Diagnostics;

namespace OnlineShopWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsRepository productRepository;
        private readonly ICartsRepository cartsRepository;

        public HomeController(IProductsRepository productRepository, ICartsRepository cartsRepository)
        {
            this.productRepository = productRepository;
            this.cartsRepository = cartsRepository;
        }
        public IActionResult Index()
        {
            var cart = cartsRepository.TryGetByUserId(Constatns.UserId);
            ViewBag.ProductCount = cart?.AmountMonitor;
            var products = productRepository.GetAllMonitors();            
            return View(products);
        }

        public IActionResult TvIndex()
        {
            var tvProducts = productRepository.GetAllTv();

            return View(tvProducts);
        }

        public IActionResult PcIndex()
        {
            var pcProducts = productRepository.GetAllPc();

            return View(pcProducts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}