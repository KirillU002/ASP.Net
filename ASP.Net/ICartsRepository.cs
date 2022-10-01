using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication
{
    public interface ICartsRepository
    {
        void Add(Product product, string userId);
        Cart TryGetByUserId(string userId);
        void DecreaseAmount(int productId, string userId);
        void Claer(string userId);
    }
}