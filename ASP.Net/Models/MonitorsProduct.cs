using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApplication.Models
{
    public class MonitorsProduct
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

        public string ImagePath { get; set; }

        public MonitorsProduct()
        {
            Id = instanceCounter;
            instanceCounter += 1;
        }

        public MonitorsProduct(string name, decimal cost, string diagonal, string imagePath, string screenResolution, string matrix, string response, string hz, string color, string company) : this()
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
        }

        public override string ToString()
        {
            return $"{Id}\n{Name}\n{Cost}";
        }

    }
}