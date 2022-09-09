using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication
{
    public interface IProductsRepository
    {
        List<MonitorsProduct> GetAllMonitors();
        List<TvProduct> GetAllTv();
        List<PcProduct> GetAllPc();
       
        MonitorsProduct TryGetByIdMonitors(int id);
        TvProduct TryGetByIdTv(int id);
        PcProduct TryGetByIdPc(int id);
    }
}