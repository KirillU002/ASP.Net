using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public interface IProductsRepository
    {
        List<Product> GetAll();
        Product TryGetById(Guid id);
        void Add(Product monitorsProduct);
        void Update(Product product);
        void Remove(Guid productId);
    }
}