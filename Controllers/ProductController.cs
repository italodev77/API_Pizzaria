using backendPizzaria.DALs.Product;
using backendPizzaria.DTOs.Product;
using backendPizzaria.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backendPizzaria.Controllers
{
    [ApiController]
    [Route("/products")]
    public class ProductController : ControllerBase
    {
        private readonly ProductDAL _productDAL;

        public ProductController(ProductDAL productDAL)
        {
            _productDAL = productDAL;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            var products = await _productDAL.GetAllProducts();
            var productDtos = products.Select(p => new ProductDto
            {
                Description = p.Description,
                Price = p.Price,
                Amount = p.Amount,
                CategoryId = (int)p.CategoryId,
            }).ToList();

            return Ok(productDtos);
        }

        [HttpGet("FindProduct/{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var product = await _productDAL.GetProductById(id);
            if (product == null)
            {
                return NotFound("Produto não encontrado.");
            }

            var productDto = new ProductDto
            {
                Description = product.Description,
                Price = product.Price,
                Amount = product.Amount,
                CategoryId = (int)product.CategoryId,
            };

            return Ok(productDto);
        }

        [HttpPost]
        public async Task<ActionResult> PostProduct(ProductDto productDto)
        {
            try
            {
                var product = new ProductModel
                {
                    Description = productDto.Description,
                    Price = productDto.Price,
                    Amount = productDto.Amount,
                    CategoryId = productDto.CategoryId
                };

                await _productDAL.AddProduct(product);
                return Ok("Produto criado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductDto productDto)
        {
            var product = await _productDAL.GetProductById(id);
            if (product == null)
            {
                return NotFound("Produto não encontrado.");
            }

            product.Description = productDto.Description;
            product.Price = productDto.Price;
            product.Amount = productDto.Amount;
            product.CategoryId = productDto.CategoryId;

            await _productDAL.UpdateProduct(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productDAL.GetProductById(id);
            if (product == null)
            {
                return NotFound("Produto não encontrado.");
            }

            await _productDAL.DeleteProduct(id);
            return NoContent();
        }
    }
}
