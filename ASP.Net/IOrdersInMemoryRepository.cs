using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication
{
    public interface IOrdersRepository
    {
        void Add(Order order);
    }
}