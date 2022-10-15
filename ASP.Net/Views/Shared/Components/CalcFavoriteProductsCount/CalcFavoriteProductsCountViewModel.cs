using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApplication;

namespace ASP.Net.Views.Shared.Components.CalcFavoriteProductsCount
{
    public class CalcFavoriteProductsCountViewModel : ViewComponent
    {
        private readonly IFavoriteRepository favoriteRepository;

        public CalcFavoriteProductsCountViewModel(IFavoriteRepository favoriteRepository)
        {
            this.favoriteRepository = favoriteRepository;
        }

        public IViewComponentResult Invoke()
        {
            var productsCount = favoriteRepository.GetAll(Constants.UserId).Count;

            return View("FavoriteProductsCountView", productsCount);
        }
    }
}
