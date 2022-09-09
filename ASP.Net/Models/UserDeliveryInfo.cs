using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApplication.Models
{
    public class UserDeliveryInfo
    {
        [Required(ErrorMessage = "Не указано имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указан телефон")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Не указан адрес")]
        public string Address { get; set; }
    }
}
