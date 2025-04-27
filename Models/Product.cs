using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingApp.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public decimal Price { get; set; }

        // Discount is computed automatically in business logic.
        public decimal Discount { get; set; }

        [StringLength(100)]
        public string Category { get; set; }
    }
}
