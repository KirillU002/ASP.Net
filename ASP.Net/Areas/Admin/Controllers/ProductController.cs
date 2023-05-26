using ASP.Net.Areas.Admin.Models;
using ASP.Net.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApplication.Models;

namespace ASP.Net.Areas.Admin.Controllers
{
    [Area(OnlineShop.Db.Constants.AdminRoleName)]
    [Authorize(Roles = OnlineShop.Db.Constants.AdminRoleName)]
    public class ProductController : Controller
    {
        private readonly IProductsRepository productRepository;
        private readonly ImagesProvider imagesProvider;

		public ProductController(IProductsRepository productRepository, ImagesProvider imagesProvider)
		{
			this.productRepository = productRepository;
			this.imagesProvider = imagesProvider;
		}
		public ActionResult Index()
        {
            var products = productRepository.GetAll();

            return View(products.ToProductViewModels());
        }

        public IActionResult Add()
        {
            return View();
        }

        public IProductsRepository GetProductRepository()
        {
            return productRepository;
        }

        [HttpPost]
        public IActionResult Add(AddProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            var imagesPaths = imagesProvider.SafeFiles(product.UploadedFiles, ImageFolders.Products);

            productRepository.Add(product.ToProduct(imagesPaths));
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(Guid productId)
        {
            var product = productRepository.TryGetById(productId);
            return View(product.ToEditProductViewModel());
        }

        [HttpPost]
        public IActionResult Edit(EditProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
			var addedImagesPaths = imagesProvider.SafeFiles(product.UploadedFiles, ImageFolders.Products);
            product.ImagePath = addedImagesPaths;
			productRepository.Update(product.ToProduct());
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(Guid productId)
        {
            productRepository.Remove(productId);
            return RedirectToAction(nameof(Index));
        }
    }
}