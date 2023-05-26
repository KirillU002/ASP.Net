using System.ComponentModel.DataAnnotations;

namespace ASP.Net.Areas.Admin.Models
{
	public class AddProductViewModel
	{
		[Required(ErrorMessage = "Не указано имя")]
		public string Name { get; set; }

		[Range(1000, 1500000, ErrorMessage = "Цена должна быть в пределах от 1000 до 1 500 000 руб.")]
		public decimal Cost { get; set; }

		[Required(ErrorMessage = "Не указана компания")]
		public string Company { get; set; }

		[Required(ErrorMessage = "Не указана диагональ")]
		public string Diagonal { get; set; }


		[Required(ErrorMessage = "Не указано разрешение экрана")]
		public string ScreenResolution { get; set; }


		[Required(ErrorMessage = "Не указана матрица")]
		public string Matrix { get; set; }


		[Required(ErrorMessage = "Не указано время отклика")]
		public string Response { get; set; }


		[Required(ErrorMessage = "Не указано Гц")]
		public string Hz { get; set; }


		[Required(ErrorMessage = "Не указан цвет")]
		public string Color { get; set; }


		[Required(ErrorMessage = "Не указано описание")]
		public string Description { get; set; }


		public IFormFile[] UploadedFiles { get; set; }
	}
}
