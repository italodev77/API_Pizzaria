using System.ComponentModel.DataAnnotations;

namespace backendPizzaria.DTOs.Category
{
    public class CategoryDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string? Description { get; set; }

    }
}
