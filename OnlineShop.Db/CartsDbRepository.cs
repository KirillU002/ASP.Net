using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class CartsDbRepository : ICartsRepository
    {
        private readonly DataBaseContext databaseContext;

        public CartsDbRepository(DataBaseContext baseContext)
        {
            this.databaseContext = baseContext;
        }

        public Cart TryGetByUserId(string userId)
        {
            return databaseContext.Carts.Include(x => x.Items).ThenInclude(x => x.Product).FirstOrDefault(x => x.UserId == userId);
        }

        public void Add(Product product, string userId)
        {
            var existingCard = TryGetByUserId(userId);
            if (existingCard == null)
            {
                var newCart = new Cart
                {
                    UserId = userId,
                };

                newCart.Items = new List<CartItem>
                {
                        new CartItem
                        {
                            Amount = 1,
                            Product = product,
                        }
                };

                databaseContext.Carts.Add(newCart);
            }
            else
            {
                var existingCardItem = existingCard.Items.FirstOrDefault(x => x.Product.Id == product.Id);
                if (existingCardItem != null)
                {
                    existingCardItem.Amount += 1;
                }
                else
                {
                    existingCard.Items.Add(new CartItem
                    {
                        Amount = 1,
                        Product = product,
                    });
                }
            }
            databaseContext.SaveChanges();
        }

        public void DecreaseAmount(Guid productId, string userId)
        {
            var existingCard = TryGetByUserId(userId);

            var existingCardItem = existingCard?.Items?.FirstOrDefault(x => x.Product.Id == productId);
            if (existingCardItem == null)
            {
                return;
            }
            existingCardItem.Amount -= 1;
            if (existingCardItem.Amount == 0)
            {
                existingCard.Items.Remove(existingCardItem);
            }
            databaseContext.SaveChanges();
        }
        public void Claer(string userId)
        {
            var existingCard = TryGetByUserId(userId);
            databaseContext.Carts.Remove(existingCard);

            databaseContext.SaveChanges();
        }
    }
}
