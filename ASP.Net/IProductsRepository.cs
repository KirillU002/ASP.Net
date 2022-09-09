﻿using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication
{
    public interface IProductsRepository
    {
        List<MonitorsProduct> GetAllMonitors();
        MonitorsProduct TryGetByIdMonitors(int id);
        void Add(MonitorsProduct monitorsProduct);
        void Update(MonitorsProduct product);
    }
}