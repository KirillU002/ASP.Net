namespace OnlineShopWebApplication.Models
{
    public class CartItemViewModel
    {
        public Guid Id { get; set; }
        public ProductViewModel Product { get; set; }
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
