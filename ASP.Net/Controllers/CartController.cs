using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApplication.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductsRepository productRepository;
        private readonly ICartsRepository cartsRepository;

        public CartController(IProductsRepository productRepository, ICartsRepository cartsRepository)
        {
            this.productRepository = productRepository;
            this.cartsRepository = cartsRepository;
        }

        public IActionResult Index()
        {
            var cart = cartsRepository.TryGetByUserId(Constatns.UserId);
            return View(cart);
        }

        public IActionResult AddMonitor(int productId)
        {
            var product = productRepository.TryGetByIdMonitors(productId);
            cartsRepository.AddMonitor(product, Constatns.UserId);

            return RedirectToAction("Index");
        }

        public IActionResult DecreaseAmountMonitor(int productId)
        {
            cartsRepository.DecreaseAmountMonitor(productId, Constatns.UserId);

            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            cartsRepository.Claer(Constatns.UserId);
            return RedirectToAction("Index");
        }
    }
}
