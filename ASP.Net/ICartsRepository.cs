using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication
{
    public interface ICartsRepository
    {
        void AddMonitor(MonitorsProduct product, string userId);
        void AddTv(TvProduct tvProduct, string userId);
        void AddPc(PcProduct pcProduct, string userId);
        CartMonitor TryGetByUserId(string userId);
        CartTv TryGetByUserIdTv(string userId);
        CartPc TryGetByUserIdPc(string userId);
        void DecreaseAmountMonitor(int productId, string userId);
        void DecreaseAmountTv(int productId, string userId);
        void DecreaseAmountPc(int productId, string userId);
        void Claer(string userId);
    }
}