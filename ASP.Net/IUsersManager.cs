using ASP.Net.Models;

namespace ASP.Net
{
    public interface IUsersManager
    {
        void Add(UserAccount user);
        List<UserAccount> GetAll();
        UserAccount TryGetByName(string name);
        void ChangePassword(string userName, string newPassword);
    }
}