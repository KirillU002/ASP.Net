namespace OnlineShopWebApplication.Models
{
    public class CartTv
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public List<CartItemTv> Items { get; set; }
        public decimal Cost
        {
            get
            {
                return Items?.Sum(x => x.CostTv) ?? 0;
            }
        }

        public int AmountTv
        {
            get
            {
                return Items?.Sum(x => x.Amount)  ?? 0;
            }
        }
    }
}
