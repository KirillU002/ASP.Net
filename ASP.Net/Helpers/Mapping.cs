using ASP.Net.Areas.Admin.Models;
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
                Matrix = product.Matrix,
                Response = product.Response,
                ScreenResolution = product.ScreenResolution,
                ImagesPaths = product.Image.Select(x => x.Url).ToArray()
            };
        }

        public static Product ToProduct(this AddProductViewModel addProductViewModel, List<string> imagesPaths)
        {
            return new Product
            {
                Name = addProductViewModel.Name,
                Cost = addProductViewModel.Cost,
                Color = addProductViewModel.Color,
                Company = addProductViewModel.Company,
                Description = addProductViewModel.Description,
                Diagonal = addProductViewModel.Diagonal,
                Hz = addProductViewModel.Hz,
                Image = ToImages(imagesPaths),
                Matrix = addProductViewModel.Matrix,
                Response = addProductViewModel.Response,
                ScreenResolution = addProductViewModel.ScreenResolution
            };
        }

		public static EditProductViewModel ToEditProductViewModel(this Product product)
		{
			return new EditProductViewModel
			{
                Id = product.Id,
				Name = product.Name,
				Cost = product.Cost,
				Color = product.Color,
				Company = product.Company,
				Description = product.Description,
				Diagonal = product.Diagonal,
				Hz = product.Hz,
				ImagePath = product.Image.ToPaths(),
				Matrix = product.Matrix,
				Response = product.Response,
				ScreenResolution = product.ScreenResolution
			};
		}

		public static Product ToProduct(this EditProductViewModel editProduct)
		{
			return new Product
			{
                Id = editProduct.Id,
				Name = editProduct.Name,
				Cost = editProduct.Cost,
				Color = editProduct.Color,
				Company = editProduct.Company,
				Description = editProduct.Description,
				Diagonal = editProduct.Diagonal,
				Hz = editProduct.Hz,
				Image = editProduct.ImagePath.ToImages(),
				Matrix = editProduct.Matrix,
				Response = editProduct.Response,
				ScreenResolution = editProduct.ScreenResolution
			};
		}

		public static List<Image> ToImages(this List<string> paths)
		{
            return paths.Select(x => new Image { Url = x }).ToList();
		}

		public static List<string> ToPaths(this List<Image> paths)
		{
			return paths.Select(x => x.Url).ToList();
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

        public static UserViewModel ToUserViewModel(this User user) 
        {
            return new UserViewModel
            {
                Name = user.UserName,
                Phone = user.PhoneNumber
            };
        }
    }
}
