using backendPizzaria.Data.Persistence;
using backendPizzaria.DTOs;
using backendPizzaria.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backendPizzaria.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly ApiDbContext _dbContext;
        public ProductController(ApiDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetProducts()
        {
            return await _dbContext.Products.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductModel>> GetProduct(int id)
        {
            var produto = await _dbContext.Products.FindAsync(id);

            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult<ProductModel>> PostProduct(ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = new ProductModel
            {
                Description = productDto.Description,
                Price = productDto.Price,
                Amount = productDto.Amount,
                CategoryId = productDto.CategoryId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutProduto(int id, ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var produto = await _dbContext.Products.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            produto.Description = productDto.Description;
            produto.Price = productDto.Price;
            produto.Amount = productDto.Amount;
            produto.CategoryId = productDto.CategoryId;
            produto.UpdatedAt = DateTime.Now;

            _dbContext.Products.Update(produto);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:int}")]

        public async Task<IActionResult> DeleteProduct(int id)
        {
            var produto = await _dbContext.Products.FindAsync(id);

            _dbContext.Products.Remove(produto);
            await _dbContext.SaveChangesAsync();    

            return NoContent();

        }


    }
}
