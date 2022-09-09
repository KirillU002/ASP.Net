namespace OnlineShopWebApplication.Models
{
    public class CartPc
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public List<CartItemPc> Items { get; set; }
        public decimal Cost
        {
            get
            {
                return Items?.Sum(x => x.CostPc) ?? 0;
            }
        }

        public decimal AmountPc
        {
            get
            {
                return Items?.Sum(x => x.Amount) ?? 0;
            }
        }
    }
}
