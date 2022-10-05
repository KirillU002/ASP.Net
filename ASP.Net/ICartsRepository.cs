﻿using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication
{
    public interface ICartsRepository
    {
        void Add(ProductViewModel product, string userId);
        Cart TryGetByUserId(string userId);
        void DecreaseAmount(Guid productId, string userId);
        void Claer(string userId);
    }
}