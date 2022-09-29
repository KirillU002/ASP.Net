using ASP.Net.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApplication;
using OnlineShopWebApplication.Models;

namespace ASP.Net.Areas.Admin.Controllers
{
    [Area ("Admin")]
    public class AdminController : Controller
    {
        private readonly IProductsRepository productRepository;
        private readonly IOrdersRepository ordersRepository;
        private readonly IRolesRepository rolesRepository;
        public AdminController(IProductsRepository productRepository, IOrdersRepository ordersRepository, IRolesRepository rolesRepository)
        {
            this.productRepository = productRepository;
            this.ordersRepository = ordersRepository;
            this.rolesRepository = rolesRepository;
        }

        public ActionResult Orders()
        {
            var orders = ordersRepository.GetAll();
            return View(orders);
        }

        public ActionResult OrderDetails(Guid orderId)
        {
            var order = ordersRepository.TryGetById(orderId);
            return View(order);
        }

        public ActionResult UpdateOrderStatus(Guid orderId, OrderStatus status)
        {
            ordersRepository.UpdateStatus(orderId, status);
            return RedirectToAction("Orders");
        }

        public ActionResult Users()
        {
            return View();
        }

        public ActionResult Roles()
        {
            var roles = rolesRepository.GetAll();
            return View(roles);
        }

        public ActionResult RemoveRole(string roleName)
        {
            rolesRepository.Remove(roleName);
            return RedirectToAction("Roles");
        }

        public ActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddRole(Role role)
        {
            if (rolesRepository.TryGetByName(role.Name) != null)
            {
                ModelState.AddModelError("", "Такая роль уже существует");
            }
            if (ModelState.IsValid)
            {
                rolesRepository.Add(role);
                return RedirectToAction("Roles");
            }
            return View(role);
        }

        public ActionResult Products()
        {
            var products = productRepository.GetAll();
            return View(products);
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        public IProductsRepository GetProductRepository()
        {
            return productRepository;
        }

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                return View(product);
            }

            productRepository.Add(product);
            return RedirectToAction("Products");
        }

        public IActionResult EditProduct(int productId)
        {
            var product = productRepository.TryGetById(productId);
            return View(product);
        }

        [HttpPost]
        public ActionResult EditProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                return View(product);
            }

            productRepository.Update(product);
            return RedirectToAction("Products");
        }
    }
}
