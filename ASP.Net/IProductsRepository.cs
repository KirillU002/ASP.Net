using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication
{
    public interface IProductsRepository
    {
        List<Product> GetAll();
        Product TryGetById(int id);
        void Add(Product monitorsProduct);
        void Update(Product product);
        void Remove(int productId);
    }
}