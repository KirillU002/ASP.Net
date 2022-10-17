using ASP.Net.Models;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApplication;

namespace ASP.Net.Areas.Admin.Controllers;

[Area ("Admin")]
public class OrderController : Controller
{
    private readonly IOrdersRepository ordersRepository;
    public OrderController(IOrdersRepository ordersRepository)
    {
        this.ordersRepository = ordersRepository;
    }

    public ActionResult Index()
    {
        var orders = ordersRepository.GetAll();
        return View(orders);
    }

    public ActionResult OrderDetails(Guid orderId)
    {
        var order = ordersRepository.TryGetById(orderId);
        return View(order);
    }

    public ActionResult UpdateOrderStatus(Guid orderId, OrderStatusViewModel status)
    {
        ordersRepository.UpdateStatus(orderId, status);
        return RedirectToAction(nameof(Index));
    }
}
