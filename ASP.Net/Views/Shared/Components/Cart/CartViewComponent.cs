﻿using ASP.Net.Helpers;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApplication;

namespace ASP.Net.Views.Shared.ViewComponents.CartViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartsRepository cartsRepository;

        public CartViewComponent(ICartsRepository cartsRepository)
        {
            this.cartsRepository = cartsRepository;
        }

        public IViewComponentResult Invoke()
        {
            var cart = cartsRepository.TryGetByUserId(Constants.UserId);

            var cartViewModel = cart.ToCartViewModel();

            var productCounts = cartViewModel?.Amount ?? 0;

            return View("Cart", productCounts);
        }
    }
}
