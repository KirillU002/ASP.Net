using ASP.Net.Helpers;
using ASP.Net.Models;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
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
        public IActionResult Buy(UserDeliveryInfoViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index), user);
            }

            var exsistingCart = cartsRepository.TryGetByUserId(Constants.UserId);

            var exsistingCartViewModel = Mapping.ToCartViewModel(exsistingCart);

            var order = new OrderViewModel
            {
                User = user,
                CartItems = exsistingCartViewModel.Items,
            };
            ordersRepository.Add(order);

            cartsRepository.Claer(Constants.UserId);
            return View();
        }
    }
}
