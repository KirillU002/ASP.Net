namespace OnlineShopWebApplication.Models
{
    public class TvProduct
    {
        private static int instanceCounter = 0;
        public int Id { get; }
        public string Name { get; }
        public decimal Cost { get; }
        public string Company { get; }
        public string Diagonal { get; }
        public string ScreenResolution { get; }
        public string Matrix { get; }
        public string Response { get; }
        public string Hz { get; }
        public string Color { get; }
        public string ImagePath { get; }

        public TvProduct(string name, decimal cost, string diagonal, string imagePath, string screenResolution, string matrix, string response, string hz, string color, string company)
        {
            Id = instanceCounter;
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

            instanceCounter += 1;            
        }

        public override string ToString()
        {
            return $"{Id}\n{Name}\n{Cost}";
        }

    }
}