using static System.Net.Mime.MediaTypeNames;

namespace OnlineShop.Db.Models
{
    public class Product
    {
        public Guid Id { get; set; }
		public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Company { get; set; }
        public string Diagonal { get; set; }
        public string ScreenResolution { get; set; }
        public string Matrix { get; set; }
        public string Response { get; set; }
        public string Hz { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public List<CartItem> CartItems { get; set; }
        public List<Image> Images { get; set; }

		public Product()
		{
			CartItems = new List<CartItem>();
			Images = new List<Image>();
		}
		public Product(Guid id, string name, decimal cost, string company, string diagonal, string screenResolution, string matrix, string response, string hz, string color, string description) : this()
		{
			Id = id;
			Name = name;
			Cost = cost;
			Company = company;
			Diagonal = diagonal;
			ScreenResolution = screenResolution;
			Matrix = matrix;
			Response = response;
			Hz = hz;
			Color = color;
			Description = description;
		}
	}
}