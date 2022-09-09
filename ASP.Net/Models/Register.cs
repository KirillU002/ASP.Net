namespace OnlineShopWebApplication.Models
{
    public class Register
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public bool PasswordVerification()
        {
            return Password == ConfirmPassword;
        }
    }
}
