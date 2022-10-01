using System.ComponentModel.DataAnnotations;

namespace ASP.Net.Areas.Admin.Models
{
    public class Role
    {
        [Required(ErrorMessage = "Пустое поле")]
        public string Name { get; set; }
    }
}
