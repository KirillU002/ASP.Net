using ASP.Net.Helpers;
using ASP.Net.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApplication;

namespace ASP.Net.Areas.Admin.Controllers
{

    [Area(OnlineShop.Db.Constants.AdminRoleName)]
    [Authorize(Roles = OnlineShop.Db.Constants.AdminRoleName)]
    public class OrderController : Controller
    {
        private readonly IOrdersDbRepository ordersRepository;
        public OrderController(IOrdersDbRepository ordersRepository)
        {
            this.ordersRepository = ordersRepository;
        }

        public ActionResult Index()
        {
            var orders = ordersRepository.GetAll();
            return View(orders.Select(order => order.ToOrderViewModel()).ToList());
        }

        public ActionResult OrderDetails(Guid orderId)
        {
            var order = ordersRepository.TryGetById(orderId);
            return View(order.ToOrderViewModel());
        }

        public ActionResult UpdateOrderStatus(Guid orderId, OrderStatusViewModel status)
        {
            ordersRepository.UpdateStatus(orderId, (OrderStatus)(int)status);
            return RedirectToAction(nameof(Index));
        }
    }
}