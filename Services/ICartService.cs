using OnlineShoppingApp.Models;

namespace OnlineShoppingApp.Services
{
    public interface ICartService
    {
        Task AddProductAsync(int productId, int quantity);
        Task RemoveProductAsync(int productId);
        Task<PurchaseSummary> GetPurchaseSummaryAsync();
    }
}
