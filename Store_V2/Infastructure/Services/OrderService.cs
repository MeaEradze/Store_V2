using Store.Domain;
using Store_V2.Infastructure.Interfaces;
using Store_V2.Infastructure;
using Microsoft.EntityFrameworkCore;
public class OrderService : IOrderService
{
    private readonly Store_V2_DbContext _context;
    private readonly ICartService _cartService;
    private readonly IProductService _productService;

    public OrderService(Store_V2_DbContext context, ICartService cartService, IProductService productService)
    {
        _context = context;
        _cartService = cartService;
        _productService = productService;
    }

    public async Task<Orders> CreateOrderAsync(int customerId)
    {
        var cart = await _cartService.GetCartAsync(customerId);
        if (cart == null || cart.CartItems.Count == 0) return null;

        var order = new Orders
        {
            CustomerId = customerId,
            CreatedDate = DateTime.UtcNow,
            TotalPrice = cart.TotalPrice,
            OrderItems = cart.CartItems.Select(ci => new OrderItems
            {
                CartItemId = ci.Id,
            }).ToList()
        };

        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        return order;
    }

    public async Task<bool> FinalizeOrderAsync(int orderId)
    {
        var order = await _context.Orders.Include(o => o.OrderItems)
                                          .ThenInclude(oi => oi.CartItem)
                                          .FirstOrDefaultAsync(o => o.Id == orderId);
        if (order == null) return false;

        foreach (var orderItem in order.OrderItems)
        {
            var cartItem = orderItem.CartItem;
            var product = cartItem.Product;

            if (!await _productService.UpdateProductStockAsync(product.Id, cartItem.Quantity))
                return false;
        }

        _context.Orders.Update(order);
        await _context.SaveChangesAsync();
        return true;
    }
}
