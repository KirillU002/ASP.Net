using OnlineShopWebApplication.Models;

namespace ASP.Net.Models
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public UserDeliveryInfoViewModel User { get; set; }
        public List<CartItemViewModel> CartItems { get; set; }
        public OrderStatusViewModel Status { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public OrderViewModel()
        {
            Id = Guid.NewGuid();
            Status = OrderStatusViewModel.Created;
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
