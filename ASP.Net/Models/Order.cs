namespace OnlineShopWebApplication.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public UserDeliveryInfo User { get; set; }
        public List<CartItemMonitor> CartItemsMonitor { get; set; }
        public List<CartItemTv> CartItemsTv { get; set; }
        public List<CartItemPc> CartItemsPc { get; set; }

        public Order()
        {
            Id=Guid.NewGuid();
        }
    }
}
