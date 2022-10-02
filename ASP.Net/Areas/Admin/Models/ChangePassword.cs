using System.ComponentModel.DataAnnotations;

namespace ASP.Net.Models
{
    public class ChangePassword
    {
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
