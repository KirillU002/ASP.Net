using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public interface ICartsRepository
    {
        void Add(Product product, string userId);
        Cart TryGetByUserId(string userId);
        void DecreaseAmount(Guid productId, string userId);
        void Claer(string userId);
    }
}