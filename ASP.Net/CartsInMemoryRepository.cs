using OnlineShopWebApplication.Models;
using System.Linq;

namespace OnlineShopWebApplication
{
    public class CartsInMemoryRepository : ICartsRepository
    {
        private List<CartMonitor> carts = new List<CartMonitor>();
        public CartMonitor TryGetByUserId(string userId)
        {
            return carts.FirstOrDefault(x => x.UserId == userId);
        }

        public void AddMonitor(MonitorsProduct product, string userId)
        {
            var existingCard = TryGetByUserId(userId);
            if (existingCard == null)
            {
                var newCart = new CartMonitor
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    Items = new List<CartItemMonitor>
                    {
                        new CartItemMonitor
                        {
                            Id = Guid.NewGuid(),
                            Amount = 1,
                            Product = product
                        }
                    }
                };
                carts.Add(newCart);
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
                    existingCard.Items.Add(new CartItemMonitor
                    {
                        Id = Guid.NewGuid(),
                        Amount = 1,
                        Product = product
                    });
                }
            }
        }

        public void DecreaseAmountMonitor(int productId, string userId)
        {
            var existingCard = TryGetByUserId(userId);

            var existingCardItem = existingCard?.Items?.FirstOrDefault(x => x.Product.Id == productId);
            if (existingCardItem == null)
            {
                return;
            }
            existingCardItem.Amount -= 1;
            if(existingCardItem.Amount == 0)
            {
                existingCard.Items.Remove(existingCardItem);
            }
        }
        public void Claer(string userId)
        {
            var existingCard = TryGetByUserId(userId);
            carts.Remove(existingCard);
        }
    }
}
