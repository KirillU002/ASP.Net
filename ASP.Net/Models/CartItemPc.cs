namespace OnlineShopWebApplication.Models
{
    public class CartItemPc
    {
        public Guid Id { get; set; }
        public PcProduct PcProduct { get; set; }
        public int Amount { get; set; }
        public decimal CostPc
        {
            get
            {
                return PcProduct.Cost * Amount;
            }
        }
    }
}
