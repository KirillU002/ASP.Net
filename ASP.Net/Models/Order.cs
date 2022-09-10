namespace OnlineShopWebApplication.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public UserDeliveryInfo User { get; set; }
        public List<CartItem> CartItems { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public Order()
        {
            Id=Guid.NewGuid();
            Status = OrderStatus.Created;
            CreatedDateTime = DateTime.Now;
        }

        public decimal Cost
        {
            get
            {
                return CartItems?.Sum(x => x.CostMonitor) ?? 0;
            }
        }
    }
}
