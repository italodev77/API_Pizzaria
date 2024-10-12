using System.ComponentModel.DataAnnotations;

namespace backendPizzaria.Models
{
    public class OrderItemsModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Amount { get; set; }

        public DateTime? Created_at { get; set; } = DateTime.Now;

        public DateTime? Updated_at { get; set; } = DateTime.Now;

        public int OrderId { get; set; }

        public OrderModel? Order { get; set; }

        public Guid ProductId { get; set; }

        public ProductModel? Product { get; set; }
    }
}
