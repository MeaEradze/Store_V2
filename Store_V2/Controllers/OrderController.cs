using Microsoft.AspNetCore.Mvc;
using Store_V2.Infastructure.Interfaces;

namespace Store_V2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("{customerId}")]
        public async Task<ActionResult> CreateOrder(int customerId)
        {
            var order = await _orderService.CreateOrderAsync(customerId);
            if (order == null) return BadRequest("Failed to create order.");

            return Ok(order);
        }

        [HttpPut("{orderId}/finalize")]
        public async Task<ActionResult> FinalizeOrder(int orderId)
        {
            bool result = await _orderService.FinalizeOrderAsync(orderId);
            if (!result) return BadRequest("Failed to finalize order.");

            return Ok();
        }
    }
}
