namespace OnlineShopWebApplication.Models
{
    public class CartItem
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public int Amount { get; set; }//количество
        public decimal CostMonitor
        {
            get
            {
                return Product.Cost * Amount;
            }
        }
    }
}
