using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class CompareDbRepository : ICompareRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public CompareDbRepository(DataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }

        public void Add(string userId, Product product)
        {
            var existingProduct = dataBaseContext.CompareProducts.FirstOrDefault(x => x.UserId == userId && x.Product.Id == product.Id);
            if(existingProduct == null)
            {
                dataBaseContext.CompareProducts.Add(new CompareProduct { Product = product, UserId = userId });
                dataBaseContext.SaveChanges();
            }
        }

        public void Clear(string userId)
        {
            var userFavoriteProducts = dataBaseContext.CompareProducts.Where(x => x.UserId == userId).ToList();
            dataBaseContext.CompareProducts.RemoveRange(userFavoriteProducts);
            dataBaseContext.SaveChanges();
        }

        public List<Product> GetAll(string userId)
        {
            return dataBaseContext.CompareProducts.Where(x => x.UserId == userId)
                                            .Include(x => x.Product)
                                            .Select(x => x.Product)
                                            .ToList();
        }

        public void Remove(string userId, Guid productId)
        {
            var removingFavorite = dataBaseContext.CompareProducts.FirstOrDefault(x => x.UserId == userId && x.Product.Id == productId);
            dataBaseContext.CompareProducts.Remove(removingFavorite);
            dataBaseContext.SaveChanges();
        }
    }
}
