using ASP.Net.Models;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public interface IOrdersDbRepository
    {
        void Add(Order order);
        List<Order> GetAll();
        Order TryGetById(Guid id);
        void UpdateStatus(Guid orderId, OrderStatus newStatus);
    }
}