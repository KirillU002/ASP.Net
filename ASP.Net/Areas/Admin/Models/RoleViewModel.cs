using System.ComponentModel.DataAnnotations;

namespace ASP.Net.Areas.Admin.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage = "Пустое поле")]
        public string Name { get; set; }

        public override bool Equals(object? obj)
        {
            var role = (RoleViewModel)obj;
            return Name == role.Name;
        }
    }
}
