using Microsoft.AspNetCore.Mvc;
using ProductApplication.DTO;
using ProductApplication.Interfaces;
using Serilog;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _service;
        
       
        public ProductController(IProductService service)
        {
            _service = service;
            
           
        }
        [HttpPost("AddProducts")]
        public async Task<IActionResult> AddProduct(ProductsDTO product)
        {
            try
            {
                var newProduct = await _service.AddProduct(product);
                if (newProduct == null)
                {
                    Log.Warning("Failed to add product {@Product}", product);
                    return BadRequest();
                }
                Log.Information("Product added successfully. Product details: {@Product}", newProduct);
                return Ok(newProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }

        }
        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GettAllProducts()
        {
            try
            {
                var allProducts = await _service.GetAllProducts();
                if (allProducts == null)
                {
                    Log.Warning("No products found. Returning NotFound.");
                    return NotFound("List is empty ");
                }
                Log.Information("Retrieved {ProductCount} products. {@Product}", allProducts.Count, allProducts);
                return Ok(allProducts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
        [HttpGet("GetProductById/{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            try
            {
                var product = await _service.GetProductById(id);
                if (product != null)
                {
                    Log.Information("Retrieved product by ID {ProductId}. Product details: {@Product}", id, product);
                    return Ok(product);
                }
            }
            catch
            {
                var product = await _service.GetProductById(id);
                if (product != null)
                {
                    Log.Information("Retrieved product by ID {ProductId}. Product details: {@Product}", id, product);
                    return Ok(product);
                }
            }


            Log.Warning("No product found with ID {ProductId}.", id);
            return NotFound("Product with this ID doesn't exists");
        }
        [HttpPut("updateProduct")]
        public async Task<IActionResult> UpdateProduct(ProductsDTO products)
        {
            if (products == null)
            {
                Log.Error("Retrieved Products is null {@Products}", products);
                return BadRequest("Product is empty");
            }
            var updateProduct = await _service.UpdateProduct(products);
            if (updateProduct != null)
            {
                Log.Information("Product is updated {@updateProduct}", updateProduct);
                return Ok(updateProduct);
            }
            else
            {
                return NotFound("Product is null");
            }
        }
        [HttpDelete("deleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var response = await _service.DeleteProduct(id);
            return Ok(response);
        }
    }
}
