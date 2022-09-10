using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication
{
    public interface ICartsRepository
    {
        void AddMonitor(Product product, string userId);
        Cart TryGetByUserId(string userId);
        void DecreaseAmountMonitor(int productId, string userId);
        void Claer(string userId);
    }
}