using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }//доступ к таблицам

        public DataBaseContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();//создаем бд при 1 обращении
        }


    }
}
