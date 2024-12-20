using Store.Domain;
using Store_V2.Infastructure.Interfaces;
using Store_V2.Infastructure;
using Microsoft.EntityFrameworkCore;


public class CartService : ICartService
{
    private readonly Store_V2_DbContext _context;

    public CartService(Store_V2_DbContext context)
    {
        _context = context;
    }

    public async Task<Carts> GetCartAsync(int customerId)
    {
        return await _context.Carts.Include(c => c.CartItems)
                                   .ThenInclude(ci => ci.Product)
                                   .FirstOrDefaultAsync(c => c.CustomerId == customerId);
    }

    public async Task AddItemToCartAsync(int customerId, int productId, int quantity)
    {
        var cart = await GetCartAsync(customerId);
        var product = await _context.Products.FindAsync(productId);
        if (product == null || quantity <= 0) return;

        var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);
        if (cartItem == null)
        {
            cartItem = new CartItems
            {
                ProductId = productId,
                Quantity = quantity,
                TotalPrice = product.UnitPrice * quantity
            };
            cart.CartItems.Add(cartItem);
        }
        else
        {
            cartItem.Quantity += quantity;
            cartItem.TotalPrice = cartItem.Quantity * product.UnitPrice;
        }

        cart.TotalPrice = cart.CartItems.Sum(ci => ci.TotalPrice);
        cart.LastEditedDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();
    }

    public async Task RemoveItemFromCartAsync(int cartItemId)
    {
        var cartItem = await _context.CartItems.FindAsync(cartItemId);
        if (cartItem == null) return;

        var cart = await _context.Carts.FindAsync(cartItem.CartId);
        cart.CartItems.Remove(cartItem);
        cart.TotalPrice = cart.CartItems.Sum(ci => ci.TotalPrice);
        cart.LastEditedDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();
    }

    public async Task UpdateCartItemQuantityAsync(int cartItemId, int newQuantity)
    {
        var cartItem = await _context.CartItems.FindAsync(cartItemId);
        if (cartItem == null || newQuantity <= 0) return;

        var product = await _context.Products.FindAsync(cartItem.ProductId);
        if (product == null) return;

        cartItem.Quantity = newQuantity;
        cartItem.TotalPrice = newQuantity * product.UnitPrice;

        var cart = await _context.Carts.FindAsync(cartItem.CartId);
        cart.TotalPrice = cart.CartItems.Sum(ci => ci.TotalPrice);
        cart.LastEditedDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();
    }

    public async Task<decimal> GetTotalPriceAsync(int cartId)
    {
        var cart = await _context.Carts.Include(c => c.CartItems)
                                       .FirstOrDefaultAsync(c => c.Id == cartId);
        return cart?.TotalPrice ?? 0;
    }

    public async Task<bool> SaveCartAsync(Carts cart)
    {
        _context.Carts.Update(cart);
        return await _context.SaveChangesAsync() > 0;
    }
}
