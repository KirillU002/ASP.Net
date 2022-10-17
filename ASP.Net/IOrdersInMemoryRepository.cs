using ASP.Net.Models;

namespace OnlineShopWebApplication
{
    public interface IOrdersRepository
    {
        void Add(OrderViewModel order);
        List<OrderViewModel> GetAll();
        OrderViewModel TryGetById(Guid id);
        void UpdateStatus(Guid orderId, OrderStatusViewModel newStatus);
    }
}