using Store.Domain;

namespace Store_V2.Infastructure.Interfaces
{
    public interface ICartService
    {
        Task<Carts> GetCartAsync(int customerId);
        Task AddItemToCartAsync(int customerId, int productId, int quantity);
        Task RemoveItemFromCartAsync(int cartItemId);
        Task UpdateCartItemQuantityAsync(int cartItemId, int newQuantity);
        Task<decimal> GetTotalPriceAsync(int cartId);
        Task<bool> SaveCartAsync(Carts cart);
    }
}
