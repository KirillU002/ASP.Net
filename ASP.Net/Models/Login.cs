using System.ComponentModel.DataAnnotations;

namespace ASP.Net.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Не указано имя")]
        [EmailAddress(ErrorMessage = "Неверный формат email")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Пароль должен быть от 6 символов до 30")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}
