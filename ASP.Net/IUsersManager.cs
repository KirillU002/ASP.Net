using ASP.Net.Models;

namespace ASP.Net
{
    public interface IUsersManager
    {
        void Add(UserViewModel user);
        List<UserViewModel> GetAll();
        UserViewModel TryGetByName(string name);
        void ChangePassword(string userName, string newPassword);
        void Update(UserViewModel user);
        void Delete(string name);
    }
}