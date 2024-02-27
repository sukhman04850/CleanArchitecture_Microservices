using Microsoft.AspNetCore.Mvc;
using OrderApplication.DTO;
using OrderApplication.Interfaces;
using Serilog;

namespace OrderAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet("{userId}")]
        public IActionResult GetOrderById(Guid userId)
        {
            try
            {
                var order = _orderService.GetOrdersByUserId(userId);

                if (order == null)
                {
                    Log.Information("Order not found for userId {UserId}", userId);
                    return NotFound("Order not found");
                }

                Log.Information("Order retrieved successfully for userId {UserId}", userId);
                return Ok(order);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while processing GetOrderById for userId {UserId}", userId);
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult AddOrder([FromBody] OrdersDTO order)
        {
            if (order == null)
            {
                Log.Warning("Invalid order data received in AddOrder");
                return BadRequest("Invalid order data");
            }

            try
            {
                var addedOrder = _orderService.AddOrder(order);

                Log.Information("Order added successfully. OrderId: {OrderId}", addedOrder.OrderId);
                return Ok(new { Message = "Order added successfully", OrderId = addedOrder.OrderId });
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while processing AddOrder");
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
