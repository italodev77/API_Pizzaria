using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backendPizzaria.Models
{
    [Table("Category")]
    public class CategoryModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string? Description { get; set; }

        public ICollection<ProductModel>? Products { get; set; }

    }
}
