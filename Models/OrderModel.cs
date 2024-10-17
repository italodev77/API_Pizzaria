using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backendPizzaria.Models
{
    [Table("Orders")]
    public class OrderModel
    {
        [Key]
        public int Id { get; set; } 

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Table { get; set; }

        [Required]
        public bool Status { get; set; } = false;

        [Required]
        public bool Draft { get; set; } = true;

        [Required]
        public string? Name { get; set; }

        public DateTime? Created_at { get; set; } = DateTime.Now;

        public DateTime? Updated_at { get; set; } = DateTime.Now;

        public ICollection<OrderItemsModel>? Items { get; set;}
    }
}
