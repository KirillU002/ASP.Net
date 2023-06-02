namespace OnlineShop.Db.Models
{
    public class FavoriteProduct
    {

		public Guid Id { get; set; }
        public string UserId { get; set; }
        public Product Product { get; set; }
		public List<Image> Image { get; set; }

		public FavoriteProduct()
		{
			Image = new List<Image>();
		}
	}
}
