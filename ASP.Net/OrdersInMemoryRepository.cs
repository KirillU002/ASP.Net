using OnlineShopWebApplication.Models;
using System.Linq;

namespace OnlineShopWebApplication
{
    public class OrdersInMemoryRepository : IOrdersRepository
    {
        private List<Order> orders = new List<Order>();

        public void Add(Order order)
        {
            orders.Add(order);
        }
    }
}
