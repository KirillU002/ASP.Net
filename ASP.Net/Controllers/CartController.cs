using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;

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
            var cart = cartsRepository.TryGetByUserId(Constants.UserId);
            return View(cart);
        }

        public IActionResult Add(Guid productId)
        {
            var product = productRepository.TryGetById(productId);
            //cartsRepository.Add(product, Constatns.UserId);

            return RedirectToAction("Index");
        }

        public IActionResult DecreaseAmount(Guid productId)
        {
            cartsRepository.DecreaseAmount(productId, Constants.UserId);

            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            cartsRepository.Claer(Constants.UserId);
            return RedirectToAction("Index");
        }
    }
}
