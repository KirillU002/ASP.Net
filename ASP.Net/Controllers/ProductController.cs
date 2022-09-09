using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApplication.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsRepository productRepository;

        public ProductController(IProductsRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public IActionResult Index(int id)
        {
            var product = productRepository.TryGetByIdMonitors(id);
            return View(product);
        }  
        
        public IActionResult TvIndex(int id)
        {
            var tvProduct = productRepository.TryGetByIdTv(id);
            return View(tvProduct);
        }

        public IActionResult PcIndex(int id)
        {
            var pcProduct = productRepository.TryGetByIdPc(id);
            return View(pcProduct);
        }
    }    
}
