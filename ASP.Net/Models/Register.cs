using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApplication.Models
{
    public class Register
    {
        [Required(ErrorMessage = "Не указано имя")]
        [EmailAddress(ErrorMessage = "Неверный формат email")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Пароль должен быть от 6 символов до 30")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Пароль должен быть от 6 символов до 30")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}
