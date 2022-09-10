using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICartsRepository cartsRepository;
        private readonly IOrdersRepository ordersRepository;

        public OrderController(ICartsRepository cartsRepository, IOrdersRepository ordersRepository)
        {
            this.cartsRepository = cartsRepository;
            this.ordersRepository = ordersRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Buy(UserDeliveryInfo user)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", user);
            }

            var exsistingCart = cartsRepository.TryGetByUserId(Constatns.UserId);
            var order = new Order
            {
                User = user,
                CartItems = exsistingCart.Items,
            };
            ordersRepository.Add(order);

            cartsRepository.Claer(Constatns.UserId);
            return View();
        }
    }
}
