using OnlineShopWebApplication.Models;
using System.Linq;

namespace OnlineShopWebApplication
{
    public class CartsInMemoryRepository : ICartsRepository
    {
        private List<CartMonitor> carts = new List<CartMonitor>();
        private List<CartTv> cartsTv = new List<CartTv>();
        private List<CartPc> cartsPc = new List<CartPc>();

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

        public void DecreaseAmountTv(int productId, string userId)
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
        }

        public void Claer(string userId)
        {
            var existingCard = TryGetByUserId(userId);
            carts.Remove(existingCard);
        }

        public void AddTv(TvProduct tvProduct, string userId)
        {
            var existingCard = TryGetByUserIdTv(userId);
            if (existingCard == null)
            {
                var newCart = new CartTv
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    Items = new List<CartItemTv>
                    {
                        new CartItemTv
                        {
                            Id = Guid.NewGuid(),
                            Amount = 1,
                            TvProduct = tvProduct
                        }
                    }
                };
                cartsTv.Add(newCart);
            }
            else
            {
                var existingCardItem = existingCard.Items.FirstOrDefault(x => x.TvProduct.Id == tvProduct.Id);
                if (existingCardItem != null)
                {
                    existingCardItem.Amount += 1;
                }
                else
                {
                    existingCard.Items.Add(new CartItemTv
                    {
                        Id = Guid.NewGuid(),
                        Amount = 1,
                        TvProduct = tvProduct
                    });
                }
            }
        }

        public CartTv TryGetByUserIdTv(string userId)
        {
            return cartsTv.FirstOrDefault(x => x.UserId == userId);
        }


        public void AddPc(PcProduct pcProduct, string userId)
        {
            var existingCard = TryGetByUserIdPc(userId);
            if (existingCard == null)
            {
                var newCart = new CartPc
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    Items = new List<CartItemPc>
                    {
                        new CartItemPc
                        {
                            Id = Guid.NewGuid(),
                            Amount = 1,
                            PcProduct = pcProduct
                        }
                    }
                };
                cartsPc.Add(newCart);
            }
            else
            {
                var existingCardItem = existingCard.Items.FirstOrDefault(x => x.PcProduct.Id == pcProduct.Id);
                if (existingCardItem != null)
                {
                    existingCardItem.Amount += 1;
                }
                else
                {
                    existingCard.Items.Add(new CartItemPc
                    {
                        Id = Guid.NewGuid(),
                        Amount = 1,
                        PcProduct = pcProduct
                    });
                }
            }
        }

        public CartPc TryGetByUserIdPc(string userId)
        {
            return cartsPc.FirstOrDefault(x => x.UserId == userId);
        }

        public void DecreaseAmountPc(int productId, string userId)
        {
            var existingCard = TryGetByUserIdPc(userId);

            var existingCardItem = existingCard?.Items?.FirstOrDefault(x => x.PcProduct.Id == productId);
            if (existingCardItem == null)
            {
                return;
            }
            existingCardItem.Amount -= 1;
            if (existingCardItem.Amount == 0)
            {
                existingCard.Items.Remove(existingCardItem);
            }
        }
    }
}
