using OnlineShoppingApp.Models;
using OnlineShoppingApp.Repositories;

namespace OnlineShoppingApp.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;

        // Discount applies only if the total amount is above this threshold.
        private readonly decimal _discountThreshold = 5000m;
        private readonly decimal _discountRate = 0.1m; // 10% discount

        public CartService(ICartRepository cartRepository, IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }

        public async Task AddProductAsync(int productId, int quantity)
        {
            var product = await _productRepository.GetByIdAsync(productId) ?? throw new KeyNotFoundException($"Product {productId} not found");
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            var existingCartItem = await _cartRepository.GetCartItemByProductIdAsync(productId);
            if (existingCartItem != null)
            {
                existingCartItem.Quantity += quantity;
                await _cartRepository.UpdateCartItemAsync(existingCartItem);
            }
            else
            {
                var cartItem = new CartItem
                {
                    ProductId = product.Id,
                    Quantity = quantity,
                    Price = product.Price
                };
                await _cartRepository.AddCartItemAsync(cartItem);
            }

            await _cartRepository.SaveChangesAsync();
        }

        public async Task RemoveProductAsync(int productId)
        {
            var cartItem = await _cartRepository.GetCartItemByProductIdAsync(productId);
            if (cartItem != null)
            {
                await _cartRepository.RemoveCartItemAsync(cartItem);
                await _cartRepository.SaveChangesAsync();
            }
        }

        public async Task<PurchaseSummary> GetPurchaseSummaryAsync()
        {
            var items = (await _cartRepository.GetAllCartItemsAsync()).ToList();
            var total = items.Sum(i => i.Quantity * i.Price);
            decimal discount = (total > _discountThreshold) ? total * _discountRate : 0;
            var finalTotal = total - discount;

            return new PurchaseSummary
            {
                Items = items,
                TotalAmount = total,
                DiscountApplied = discount,
                FinalAmount = finalTotal
            };
        }
    }
}
