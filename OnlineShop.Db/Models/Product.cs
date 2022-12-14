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
        public string ImagePath { get; set; }

        public List<CartItem> CartItems { get; set; }

        public Product()
        {
            CartItems = new List<CartItem>();
        }
    }
}