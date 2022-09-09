using Microsoft.AspNetCore.Mvc;
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
            var cart = cartsRepository.TryGetByUserId(Constatns.UserId);
            var productCounts = cart?.AmountMonitor ?? 0;

            return View("Cart", productCounts);
        }
    }
}
