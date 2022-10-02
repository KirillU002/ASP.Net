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

        public void ChangePassword(string userName, string newPassword)
        {
            var account = TryGetByName(userName);
            account.Password = newPassword;
        }

        public void Update(UserAccount user)
        {
            var existingUser = users.FirstOrDefault(x => x.Name == user.Name);
            if(existingUser == null)
            {
                return;
            }
            existingUser.Name = user.Name;
            existingUser.Phone = user.Phone;
            existingUser.Password = user.Password;
        }

        public void Delete(string name)
        {
            var user = users.FirstOrDefault(x => x.Name == name);
            users.Remove(user);
        }
    }
}
