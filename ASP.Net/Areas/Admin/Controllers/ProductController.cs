using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
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
        return View(products);
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
    public ActionResult Add(Product product)
    {
        if (ModelState.IsValid)
        {
            return View(product);
        }

        productRepository.Add(product);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(int productId)
    {
        var product = productRepository.TryGetById(productId);
        return View(product);
    }

    [HttpPost]
    public ActionResult Edit(Product product)
    {
        if (ModelState.IsValid)
        {
            return View(product);
        }

        productRepository.Update(product);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Remove(int productId)
    {
        productRepository.Remove(productId);
        return RedirectToAction(nameof(Index));
    }
}
