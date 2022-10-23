using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApplication;

namespace ASP.Net.Views.Shared.Components.CalcFavoriteProductsCount
{
    public class CalcCompareProductsCountViewComponent : ViewComponent
    {
        private readonly ICompareRepository compareRepository;

        public CalcCompareProductsCountViewComponent(ICompareRepository compareRepository)
        {
            this.compareRepository = compareRepository;
        }

        public IViewComponentResult Invoke()
        {
            var productsCount = compareRepository.GetAll(Constants.UserId).Count;

            return View("CompareProductsCountView", productsCount);
        }
    }
}
