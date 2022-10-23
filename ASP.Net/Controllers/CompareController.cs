using ASP.Net.Helpers;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApplication;

namespace ASP.Net.Controllers
{
    public class CompareController : Controller
    {
        private readonly ICompareRepository compareRepository;
        private readonly IProductsRepository productsRepository;

        public CompareController(ICompareRepository compareRepository, IProductsRepository productsRepository = null)
        {
            this.compareRepository = compareRepository;
            this.productsRepository = productsRepository;
        }        

        public ActionResult Index()
        {
            var products = compareRepository.GetAll(Constants.UserId);
            return View(products.ToProductViewModels());
        }        

        public IActionResult Add(Guid productId)
        {
            var products = compareRepository.GetAll(Constants.UserId);

            if (products.Count >= 2)
            {
                return RedirectToAction(nameof(Index));
            }

            var product = productsRepository.TryGetById(productId);
            compareRepository.Add(Constants.UserId, product);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(Guid productId)
        {
            compareRepository.Remove(Constants.UserId, productId);
            return RedirectToAction(nameof(Index));
        }
    }
}
