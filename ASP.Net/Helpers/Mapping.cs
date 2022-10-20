using ASP.Net.Models;
using OnlineShop.Db.Models;
using OnlineShopWebApplication.Models;

namespace ASP.Net.Helpers
{
    public static class Mapping
    {
        public static List<ProductViewModel> ToProductViewModels(this List<Product> products)
        {
            var productsViewModels = new List<ProductViewModel>();

            foreach (var product in products)
            {
                productsViewModels.Add(product.ToProductViewModel());
            }
            return productsViewModels;
        }

        public static ProductViewModel ToProductViewModel(this Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Cost = product.Cost,
                Color = product.Color,
                Company = product.Company,
                Description = product.Description,
                Diagonal = product.Diagonal,
                Hz = product.Hz,
                ImagePath = product.ImagePath,
                Matrix = product.Matrix,
                Response = product.Response,
                ScreenResolution = product.ScreenResolution
            };
        }

        public static Product ToProduct(this ProductViewModel product)
        {
            return new Product
            {
                Id = product.Id,
                Name = product.Name,
                Cost = product.Cost,
                Color = product.Color,
                Company = product.Company,
                Description = product.Description,
                Diagonal = product.Diagonal,
                Hz = product.Hz,
                ImagePath = product.ImagePath,
                Matrix = product.Matrix,
                Response = product.Response,
                ScreenResolution = product.ScreenResolution
            };
        }

        public static OrderViewModel ToOrderViewModel(this Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                CreatedDateTime = order.CreatedDateTime,
                Status = (OrderStatusViewModel)(int)order.Status,
                User = order.User.ToUserDeliveryInfoViewModel(),
                CartItems = order.Items.ToCartItemViewModels()
            };
        }

        public static UserDeliveryInfoViewModel ToUserDeliveryInfoViewModel(this UserDeliveryInfo deliveryInfo)
        {
            return new UserDeliveryInfoViewModel
            {
                Name = deliveryInfo.Name,
                Address = deliveryInfo.Address,
                Phone = deliveryInfo.Phone
            };
        }

        public static CartViewModel ToCartViewModel(this Cart cart)
        {
            if (cart == null)
            {
                return null;
            }
            return new CartViewModel
            {
                Id = cart.Id,
                UserId = cart.UserId,
                Items = cart.Items.ToCartItemViewModels()
            };
        }

        public static List<CartItemViewModel> ToCartItemViewModels(this List<CartItem> cartDbItems)
        {
            var cartItems = new List<CartItemViewModel>();

            foreach (var cartDbItem in cartDbItems)
            {
                var cartItem = new CartItemViewModel
                {
                    Id = cartDbItem.Id,
                    Amount = cartDbItem.Amount,
                    Product = cartDbItem.Product.ToProductViewModel()
                };
                cartItems.Add(cartItem);
            }
            return cartItems;
        }

        public static UserDeliveryInfo ToUser(this UserDeliveryInfoViewModel user)
        {
            return new UserDeliveryInfo
            {
                Name = user.Name,
                Address = user.Address,
                Phone = user.Phone,
            };
        }
    }
}
