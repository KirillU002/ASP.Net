using ASP.Net.Areas.Admin.Models;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication
{
    public interface IRolesRepository
    {
        List<RoleViewModel> GetAll();
        RoleViewModel TryGetByName(string name);
        void Add(RoleViewModel role);
        void Remove(string name);
    }
}