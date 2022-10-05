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

        return View(Mapping.ToProductViewModels(products));
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
    public ActionResult Add(ProductViewModel product)
    {
        if (ModelState.IsValid)
        {
            return View(product);
        }

        var productDb = new Product
        {
            Name = product.Name,
            Cost = product.Cost,
            Hz = product.Hz,
            Company = product.Company,
            Description = product.Description,
            Diagonal = product.Diagonal,
            Matrix = product.Matrix,
            Response = product.Response,
            ScreenResolution = product.ScreenResolution,
            Color = product.Color
        };

        productRepository.Add(productDb);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(Guid productId)
    {
        var product = productRepository.TryGetById(productId);
        return View(product);
    }

    [HttpPost]
    public ActionResult Edit(ProductViewModel product)
    {
        if (ModelState.IsValid)
        {
            return View(product);
        }

        var productDb = new Product
        {
            Name = product.Name,
            Cost = product.Cost,
            Hz = product.Hz,
            Company = product.Company,
            Description = product.Description,
            Diagonal = product.Diagonal,
            Matrix = product.Matrix,
            Response = product.Response,
            ScreenResolution = product.ScreenResolution,
            Color = product.Color
        };

        productRepository.Update(productDb);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Remove(Guid productId)
    {
        productRepository.Remove(productId);
        return RedirectToAction(nameof(Index));
    }
}
