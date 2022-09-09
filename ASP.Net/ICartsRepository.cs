using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication
{
    public interface ICartsRepository
    {
        void AddMonitor(MonitorsProduct product, string userId);
        CartMonitor TryGetByUserId(string userId);
        void DecreaseAmountMonitor(int productId, string userId);
        void Claer(string userId);
    }
}