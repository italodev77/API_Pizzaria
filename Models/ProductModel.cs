using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backendPizzaria.Models
{
    [Table("Product")]
    public class ProductModel
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Amount { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int? CategoryId { get; set; }

        public CategoryModel? Category { get; set; }

        public ICollection<OrderItemsModel>? Items { get; set; }

        public DateTime? Created_at { get; set; } = DateTime.Now;

        public DateTime? Updated_at { get; set; } = DateTime.Now;
    }
}
