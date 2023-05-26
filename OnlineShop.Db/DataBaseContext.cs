using Microsoft.EntityFrameworkCore;
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
        public DbSet<Image> Image { get; set; }

        public DataBaseContext(DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Image>().HasOne(p => p.Product).WithMany(p => p.Image).HasForeignKey(p => p.ProductId).OnDelete(DeleteBehavior.Cascade);

            var product1Id = Guid.Parse("48240a82-9f6b-414c-97f4-f624813149b2");
            var product2Id = Guid.Parse("befe6b5b-7171-4446-b35c-5b265b81be17");
            var image1 = new Image
            {
                Id = Guid.NewGuid(),
                Url = "/images/Products/image3.png",
                ProductId = product1Id
            };

            var image2 = new Image
            {
                Id = Guid.NewGuid(),
                Url = "/images/Products/image4.jpg",
                ProductId = product2Id
            };

            modelBuilder.Entity<Image>().HasData(image1, image2);

            modelBuilder.Entity<Product>().HasData(new List<Product>()
            {
                new Product(product1Id, "Name1", 2323, "Леново", "23 дюйма", "1920х1080", "ва", "1 мс", "144 Гц", "Белый","Самый кртуой в мире монитор"),
                new Product(product2Id, "Name2", 545665, "Монитор", "23 дюйма", "1920х1080", "ва", "1 мс", "144 Гц", "Белый","Самый кртуой в мире монитор"),
            });
        }
    }
}
