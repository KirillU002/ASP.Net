using ASP.Net.Areas.Admin.Models;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication
{
    public interface IRolesRepository
    {
        List<Role> GetAll();
        Role TryGetByName(string name);
        void Add(Role role);
        void Remove(string name);
    }
}