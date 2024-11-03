using backendPizzaria.Data.Persistence;
using backendPizzaria.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace backendPizzaria.DALs.Order
{
    public class OrderDAL
    {
        private readonly ApiDbContext _dbContext;

        public OrderDAL( ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<OrderModel>> GetAllOrders()
        {
            return await _dbContext.Orders.ToListAsync();
        }

        public async Task<OrderModel> GetOrderById(int id)
        {
            return await _dbContext.Orders.FindAsync(id);
        }

        public async Task AddOrder(OrderModel order)
        {
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateOrder(OrderModel order)
        {
            _dbContext.Orders.Update(order);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteOrder(int id)
        {
            var order = await _dbContext.Products.FindAsync(id);
            if (order != null)
            {
                _dbContext.Products.Remove(order);
                await _dbContext.SaveChangesAsync();
            }
        }


    }
}
