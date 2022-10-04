using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApplication.Models
{
    public class Product
    {
        private static int instanceCounter = 0;
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указано имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указана цена")]
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
        public string ImagePath { get; set; }

        public Product()
        {
            Id = instanceCounter;
            instanceCounter += 1;
        }

        public Product(string name, decimal cost, string diagonal, string imagePath, string screenResolution, string matrix, string response, string hz, string color, string company, string description) : this()
        {
            Name = name;
            Cost = cost;
            Diagonal = diagonal;
            ScreenResolution = screenResolution;
            Matrix = matrix;
            Response = response;
            Hz = hz;
            Color = color;
            Company = company;
            ImagePath = imagePath;
            Description = description;
            Description = description;
        }

        public override string ToString()
        {
            return $"{Id}\n{Name}\n{Cost}";
        }

    }
}