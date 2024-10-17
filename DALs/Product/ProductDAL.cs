using backendPizzaria.Data.Persistence;
using backendPizzaria.Models;
using Microsoft.EntityFrameworkCore;

namespace backendPizzaria.DALs.Product
{
    public class ProductDAL
    {
        private readonly ApiDbContext _dbContext;

        public ProductDAL(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ProductModel>> GetAllProducts()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<ProductModel> GetProductById(int id)
        {
            return await _dbContext.Products.FindAsync(id);
        }

        public async Task AddProduct(ProductModel product)
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateProduct(ProductModel product)
        {
            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteProduct(int id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            if (product != null)
            {
                _dbContext.Products.Remove(product);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
