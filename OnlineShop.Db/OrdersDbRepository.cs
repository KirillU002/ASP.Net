using ASP.Net.Models;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class OrdersDbRepository : IOrdersDbRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public OrdersDbRepository(DataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }

        public void Add(Order order)
        {
            dataBaseContext.Orders.Add(order);
            dataBaseContext.SaveChanges();
        }

        public List<Order> GetAll()
        {
            return dataBaseContext.Orders.Include(x => x.User)
                                        .Include(x => x.Items).ThenInclude(x => x.Product).ToList();
        }

        public Order TryGetById(Guid id)
        {
            return dataBaseContext.Orders.Include(x => x.User)
                                    .Include(x => x.Items)
                                    .ThenInclude(x => x.Product)
                                    .FirstOrDefault(x => x.Id == id);
        }

        public void UpdateStatus(Guid orderId, OrderStatus newStatus)
        {
            var order = TryGetById(orderId);

            if (order != null)
            {
                order.Status = newStatus;
            }
        }

        public void DeleateOrder(Guid orderId)
        {

            var order = dataBaseContext.Orders.Include(x => x.Items).FirstOrDefault(x => x.Id == orderId);
            dataBaseContext.Orders.Remove(order);
            dataBaseContext.SaveChanges();
        }
    }
}
