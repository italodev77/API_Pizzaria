using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backendPizzaria.Models
{
    [Table("OrderItems")]
    public class OrderItemsModel
    {
        [Key]
        public int Id { get; set; }

        public int Amount { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; } = DateTime.Now;

        public int OrderId { get; set; }

        public OrderModel Order { get; set; }

        public int ProductId { get; set; }

        public ProductModel Product { get; set; }
    }
}
