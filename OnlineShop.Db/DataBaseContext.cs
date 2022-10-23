﻿using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<FavoriteProduct> FavoriteProducts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CompareProduct> CompareProducts { get; set; }

        public DataBaseContext(DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }
    }
}
