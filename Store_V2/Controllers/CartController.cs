using Microsoft.AspNetCore.Mvc;
using Store.Domain;
using Store_V2.Infastructure.Interfaces;

namespace Store_V2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("{customerId}")]
        public async Task<ActionResult<Carts>> GetCart(int customerId)
        {
            var cart = await _cartService.GetCartAsync(customerId);
            if (cart == null)
                return NotFound();

            return Ok(cart);
        }

        [HttpPost("{customerId}")]
        public async Task<ActionResult> AddItemToCart(int customerId, [FromBody] CartItemRequest request)
        {
            await _cartService.AddItemToCartAsync(customerId, request.ProductId, request.Quantity);
            return Ok();
        }

        [HttpPut("{cartItemId}")]
        public async Task<ActionResult> UpdateCartItem(int cartItemId, [FromBody] CartItemRequest request)
        {
            await _cartService.UpdateCartItemQuantityAsync(cartItemId, request.Quantity);
            return Ok();
        }

        [HttpDelete("{cartItemId}")]
        public async Task<ActionResult> RemoveItemFromCart(int cartItemId)
        {
            await _cartService.RemoveItemFromCartAsync(cartItemId);
            return Ok();
        }
    }

    public class CartItemRequest
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
