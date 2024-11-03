using backendPizzaria.Data.Persistence;
using backendPizzaria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backendPizzaria.DALs.OrderItems
{
    public class OrderItemDAL
    {
        private readonly ApiDbContext _dbContext;

        public OrderItemDAL(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(OrderItemsModel orderItems)
        {
            await _dbContext.OrderItems.AddAsync(orderItems);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<OrderItemsModel> GetOrderItemById(int id)
        {
            return await _dbContext.OrderItems.FindAsync(id);
        }


        public async Task<List<OrderItemsModel>> GetOrderDetailsAsync( int orderId)
        {
            return await _dbContext.OrderItems
                .Where(item => item.OrderId == orderId)
                .Include(item => item.Product)
                .Include(item => item.Order)
                .ToListAsync();
        }

        public async Task DeleteOrderItem(int id)
        {
            var orderItem = await _dbContext.OrderItems.FindAsync(id);

            if(orderItem != null)
            {
                _dbContext.OrderItems.Remove(orderItem);
                await _dbContext.SaveChangesAsync();
            }

            
        }

    }

    
}
