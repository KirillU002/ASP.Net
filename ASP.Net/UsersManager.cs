using ASP.Net.Models;

namespace ASP.Net
{
    public class UsersManager : IUsersManager
    {
        private readonly List<UserAccount> users = new List<UserAccount>();

        public List<UserAccount> GetAll()
        {
            return users;
        }
        public void Add(UserAccount user)
        {
            users.Add(user);
        }

        public UserAccount TryGetByName(string name)
        {
            return users.FirstOrDefault(x => x.Name == name);
        }
    }
}
