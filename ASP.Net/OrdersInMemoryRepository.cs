using ASP.Net.Models;
using System.Linq;

namespace OnlineShopWebApplication
{
    public class OrdersInMemoryRepository : IOrdersRepository
    {
        private List<OrderViewModel> orders = new List<OrderViewModel>();

        public void Add(OrderViewModel order)
        {
            orders.Add(order);
        }

        public List<OrderViewModel> GetAll()
        {
            return orders;
        }

        public OrderViewModel TryGetById(Guid id)
        {
            return orders.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateStatus(Guid orderId, OrderStatusViewModel newStatus)
        {
            var order = TryGetById(orderId);

            if(order != null)
            {
                order.Status = newStatus;
            }
        }
    }
}
