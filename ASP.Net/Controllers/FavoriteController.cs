using ASP.Net.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApplication;
using System.Reflection.Metadata;

namespace ASP.Net.Controllers
{
    public class FavoriteController : Controller
    {
        private readonly IFavoriteRepository favoriteRepository;
        private readonly IProductsRepository productsRepository;

        public FavoriteController(IFavoriteRepository favoriteRepository, IProductsRepository productsRepository = null)
        {
            this.favoriteRepository = favoriteRepository;
            this.productsRepository = productsRepository;
        }        

        public ActionResult Index()
        {
            var products = favoriteRepository.GetAll(Constants.UserId);
            return View(products.ToProductViewModels());
        }        

        public IActionResult Add(Guid productId)
        {
            var product = productsRepository.TryGetById(productId);
            favoriteRepository.Add(Constants.UserId, product);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(Guid productId)
        {
            favoriteRepository.Remove(Constants.UserId, productId);
            return RedirectToAction(nameof(Index));
        }
    }
}
