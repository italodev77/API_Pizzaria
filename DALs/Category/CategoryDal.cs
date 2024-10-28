using backendPizzaria.Data.Persistence;
using backendPizzaria.Models;
using Microsoft.EntityFrameworkCore;

namespace backendPizzaria.DALs.Category
{
    public class CategoryDal
    {
        private readonly ApiDbContext _dbContext;

        public CategoryDal(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CategoryModel>> GetAllAsync()
        {
            return await _dbContext.Category.ToListAsync();
        }

        public async Task<CategoryModel> GetById(int id)
        {
            return await _dbContext.Category.FindAsync(id);
        }

        public async Task AddAsync(CategoryModel category)
        {
            await _dbContext.Category.AddAsync(category);
            await _dbContext.SaveChangesAsync();    

        }
        public async Task UpdateAsync(CategoryModel category)
        {
            _dbContext.Category.Update(category);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var category = await _dbContext.Category.FindAsync(id);

            if (category != null)
            {
                _dbContext.Category.Remove(category);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
