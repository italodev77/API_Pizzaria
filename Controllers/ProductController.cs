using backendPizzaria.Data.Persistence;
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
        public async Task<ActionResult<ProductModel>> PostProduct(ProductModel produto)
        {
            _dbContext.Products.Add(produto);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = produto.Id }, produto);
        }

        [HttpPut]
        public async Task<IActionResult> PutProduto(int id, ProductModel produto)
        {
            _dbContext.Products.Update(produto);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id: int}")]

        public async Task<IActionResult> DeleteProduct(int id)
        {
            var produto = await _dbContext.Products.FindAsync(id);

            _dbContext.Products.Remove(produto);
            await _dbContext.SaveChangesAsync();    

            return NoContent();

        }


    }
}
