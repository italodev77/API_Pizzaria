using System.ComponentModel.DataAnnotations;

namespace backendPizzaria.DTOs
{
    public class ProductDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Description { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Amount { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int CategoryId { get; set; } // Renomeado para seguir convenção PascalCase
    }
}
