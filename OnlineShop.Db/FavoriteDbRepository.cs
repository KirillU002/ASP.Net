﻿using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class FavoriteDbRepository : IFavoriteRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public FavoriteDbRepository(DataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }

        public void Add(string userId, Product product, List<Image> image)
        {
            var existingProduct = dataBaseContext.FavoriteProducts.FirstOrDefault(x => x.UserId == userId && x.Product.Id == product.Id);
            if(existingProduct == null)
            {
                dataBaseContext.FavoriteProducts.Add(new FavoriteProduct { Product = product, UserId = userId });
                dataBaseContext.SaveChanges();
            }
        }

        public void Clear(string userId)
        {
            var userFavoriteProducts = dataBaseContext.FavoriteProducts.Where(x => x.UserId == userId).ToList();
            dataBaseContext.FavoriteProducts.RemoveRange(userFavoriteProducts);
            dataBaseContext.SaveChanges();
        }

        public List<Product> GetAll(string userId)
        {
            return dataBaseContext.FavoriteProducts.Where(x => x.UserId == userId)
                                            .Include(x => x.Product)
                                            .Select(x => x.Product)
                                            .ToList();
        }

        public void Remove(string userId, Guid productId)
        {
            var removingFavorite = dataBaseContext.FavoriteProducts.FirstOrDefault(x => x.UserId == userId && x.Product.Id == productId);
            dataBaseContext.FavoriteProducts.Remove(removingFavorite);
            dataBaseContext.SaveChanges();
        }
    }
}
