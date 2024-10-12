using System.ComponentModel.DataAnnotations;

namespace backendPizzaria.Models
{
    public class CategoryModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string? Description { get; set; }

        public ICollection<ProductModel>? Products { get; set; }

    }
}
