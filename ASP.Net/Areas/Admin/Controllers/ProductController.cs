using ASP.Net.Helpers;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApplication.Models;

namespace ASP.Net.Areas.Admin.Controllers;

[Area ("Admin")]
public class ProductController : Controller
{
    private readonly IProductsRepository productRepository;
    public ProductController(IProductsRepository productRepository)
    {
        this.productRepository = productRepository;
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
    public IActionResult Add(ProductViewModel product)
    {
        if (ModelState.IsValid)
        {
            return View(product);
        }

        productRepository.Add(product.ToProduct());
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(Guid productId)
    {
        var product = productRepository.TryGetById(productId);
        return View(product.ToProductViewModel());
    }

    [HttpPost]
    public IActionResult Edit(ProductViewModel product)
    {
        if (ModelState.IsValid)
        {
            return View(product);
        }

        productRepository.Update(product.ToProduct());
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Remove(Guid productId)
    {
        productRepository.Remove(productId);
        return RedirectToAction(nameof(Index));
    }
}
