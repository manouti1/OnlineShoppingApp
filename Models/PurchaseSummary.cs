namespace OnlineShoppingApp.Models
{
    public class PurchaseSummary
    {
        public ICollection<CartItem> Items { get; set; } = new List<CartItem>();
        public decimal TotalAmount { get; set; }
        public decimal DiscountApplied { get; set; }
        public decimal FinalAmount { get; set; }
    }
}
