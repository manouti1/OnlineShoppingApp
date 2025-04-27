using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingApp.Services;

namespace OnlineShoppingApp.Controllers
{

    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly ILogger<CartController> _logger;

        public CartController(ICartService cartService, ILogger<CartController> logger)
        {
            _cartService = cartService;
            _logger = logger;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(int productId, int quantity)
        {
            try
            {
                await _cartService.AddProductAsync(productId, quantity);
                return RedirectToAction("Summary");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding product with id {ProductId}", productId);
                return StatusCode(500, "An error occurred while adding product to the cart.");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Remove(int productId)
        {
            try
            {
                await _cartService.RemoveProductAsync(productId);
                TempData["Message"] = "Product removed from cart successfully";
                return RedirectToAction("Index", "Products");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error removing product from cart");
                TempData["Error"] = "Failed to remove product from cart";
                return RedirectToAction("Index", "Products");
            }
        }
        
        public async Task<IActionResult> Summary()
        {
            var summary = await _cartService.GetPurchaseSummaryAsync();
            // You can choose to return a partial view for AJAX updates.
            return View(summary);
        }
    }
}
