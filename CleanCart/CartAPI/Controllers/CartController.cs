using CartApplication.Interfaces;
using CartInfrastructure.KafkaProducer;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace CartAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IKafkaProducer _producer;
       

        public CartController(ICartService cartService, IKafkaProducer producer)
        {
            _cartService = cartService;
            _producer = producer;
            


        }
        [HttpPost("AddToCart/{userId}/{productId}")]
        public IActionResult AddToCart([FromRoute] Guid userId, [FromRoute] Guid productId)
        {
            try
            {
                var cartItem = _cartService.AddToCart(userId, productId);
                Log.Information($"Product added to cart. UserId: {userId}, ProductId: {productId}");
                return Ok(cartItem);

            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error adding product to the cart. UserId: {userId}, ProductId: {productId}");

                return BadRequest("Error adding product to the cart");
            }
        }

        [HttpGet("GettAll/{userID}")]

        public IActionResult GettCartById(Guid userId)
        {
            try
            {
                var cart = _cartService.GetCartItems(userId);
                return Ok(cart);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}", ex);
                return BadRequest();
            }


        }
        [HttpGet("ViewCartDetails/{userId}")]
        public IActionResult GetList(Guid userId)
        {
            try
            {
                var cart = _cartService.ViewCartDetails(userId);
                Log.Information($"Retrieved cart details for UserId: {userId}");
                return Ok(cart);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error retrieving cart details. UserId: {userId}");
                return BadRequest();
            }



        }
        [HttpPost("PlaceOrder/{userId}")]
        public IActionResult PlaceOrder(Guid userId)
        {
            try
            {
                var order = _cartService.ViewOrderItems(userId);
                _producer.ProduceMessage(userId, order);
                var deleteCart = _cartService.DeleteCartByUserId(userId);
                Log.Information($"Order placed for UserId: {userId}");
                return Ok(order);

            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error placing order. UserId: {userId}");
                return BadRequest();
            }



        }

    }
}
