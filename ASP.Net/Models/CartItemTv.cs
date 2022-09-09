namespace OnlineShopWebApplication.Models
{
    public class CartItemTv
    {
        public Guid Id { get; set; }
        public TvProduct TvProduct { get; set; }
        public int Amount { get; set; }
        public decimal CostTv
        {
            get
            {
                return TvProduct.Cost * Amount;
            }
        }
    }
}
