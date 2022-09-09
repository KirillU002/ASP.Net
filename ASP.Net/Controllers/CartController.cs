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

        public IActionResult TvIndex()
        {
            var cart = cartsRepository.TryGetByUserIdTv(Constatns.UserId);
            return View(cart);
        }

        public IActionResult PcIndex()
        {
            var cart = cartsRepository.TryGetByUserIdPc(Constatns.UserId);
            return View(cart);
        }

        public IActionResult AddMonitor(int productId)
        {
            var product = productRepository.TryGetByIdMonitors(productId);
            cartsRepository.AddMonitor(product, Constatns.UserId);

            return RedirectToAction("Index");
        }

        public IActionResult AddTv(int productId)
        {
            var product = productRepository.TryGetByIdTv(productId);
            cartsRepository.AddTv(product, Constatns.UserId);

            return RedirectToAction("TvIndex");
        }

        public IActionResult AddPc(int productId)
        {
            var product = productRepository.TryGetByIdPc(productId);
            cartsRepository.AddPc(product, Constatns.UserId);

            return RedirectToAction("PcIndex");
        }

        public IActionResult DecreaseAmountMonitor(int productId)
        {
            cartsRepository.DecreaseAmountMonitor(productId, Constatns.UserId);

            return RedirectToAction("Index");
        }

        public IActionResult DecreaseAmountTv(int productId)
        {
            cartsRepository.DecreaseAmountTv(productId, Constatns.UserId);

            return RedirectToAction("TvIndex");
        }

        public IActionResult DecreaseAmountPc(int productId)
        {
            cartsRepository.DecreaseAmountPc(productId, Constatns.UserId);

            return RedirectToAction("PcIndex");
        }

        public IActionResult Clear()
        {
            cartsRepository.Claer(Constatns.UserId);
            return RedirectToAction("Index");
        }
    }
}
