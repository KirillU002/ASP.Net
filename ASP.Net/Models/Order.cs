namespace OnlineShopWebApplication.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public UserDeliveryInfo User { get; set; }
        public List<CartItemMonitor> CartItemsMonitor { get; set; }

        public Order()
        {
            Id=Guid.NewGuid();
        }
    }
}
