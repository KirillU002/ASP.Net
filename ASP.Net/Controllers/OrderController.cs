using ASP.Net.Helpers;
using ASP.Net.Models;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICartsRepository cartsRepository;
        private readonly IOrdersDbRepository ordersRepository;

        public OrderController(ICartsRepository cartsRepository, IOrdersDbRepository ordersRepository)
        {
            this.cartsRepository = cartsRepository;
            this.ordersRepository = ordersRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Buy(UserDeliveryInfoViewModel userViewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index), userViewModel);
            }

            var exsistingCart = cartsRepository.TryGetByUserId(Constants.UserId);

            var order = new Order
            {
                User = userViewModel.ToUser(),
                Items = exsistingCart.Items,
            };
            ordersRepository.Add(order);

            cartsRepository.Claer(Constants.UserId);
            return View();
        }
    }
}
