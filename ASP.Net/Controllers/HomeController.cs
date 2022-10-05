using ASP.Net.Models;
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
            var productsViewModels = new List<ProductViewModel>();

            foreach (var product in products)
            {
                var productViewModel = new ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Cost = product.Cost,
                    Color = product.Color,
                    Company = product.Company,
                    Description = product.Description,
                    Diagonal = product.Diagonal,
                    Hz = product.Hz,
                    ImagePath = product.ImagePath,
                    Matrix = product.Matrix,
                    Response = product.Response,
                    ScreenResolution = product.ScreenResolution
                };
                productsViewModels.Add(productViewModel);
            }
            return View(productsViewModels);
        }
    }
}