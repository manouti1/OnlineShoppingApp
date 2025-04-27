using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingApp.Models
{
    public class CartItem
    {
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }

        public decimal Price { get; set; }

        // Navigation property to Product.
        public Product Product { get; set; }
    }
}
