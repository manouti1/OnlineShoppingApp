using OnlineShoppingApp.Models;

namespace OnlineShoppingApp.Repositories
{
    public interface ICartRepository
    {
        Task<CartItem> GetCartItemByProductIdAsync(int productId);
        Task<IEnumerable<CartItem>> GetAllCartItemsAsync();
        Task AddCartItemAsync(CartItem cartItem);
        Task RemoveCartItemAsync(CartItem cartItem);
        Task UpdateCartItemAsync(CartItem cartItem);
        Task SaveChangesAsync();
    }
}
