using backendPizzaria.Models;
using Microsoft.EntityFrameworkCore;

namespace backendPizzaria.Data.Persistence
{
    public class ApiDbContext(DbContextOptions options): DbContext(options)
    {
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<CategoryModel> Category { get; set; }
        public DbSet<OrderModel> Order { get; set; }
        public DbSet<OrderItemsModel> orderItems { get; set; }
        
    }
}
