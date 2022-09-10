using System.ComponentModel.DataAnnotations;

namespace ASP.Net.Models
{
    public class Role
    {
        [Required(ErrorMessage = "Пустое поле")]
        public string Name { get; set; }
    }
}
