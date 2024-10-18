using backendPizzaria.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace backendPizzaria.Data.Persistence
{
    public class ApiDbContext(DbContextOptions options): IdentityDbContext(options)
    {
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<CategoryModel> Category { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<OrderItemsModel> OrderItems { get; set; }


    }
}
