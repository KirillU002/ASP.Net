namespace OnlineShopWebApplication.Models
{
    public class CartItemMonitor
    {
        public Guid Id { get; set; }
        public MonitorsProduct Product { get; set; }
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
