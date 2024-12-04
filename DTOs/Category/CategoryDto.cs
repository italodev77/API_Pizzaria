using System.ComponentModel.DataAnnotations;

namespace backendPizzaria.DTOs.Category
{
    public class CategoryDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string? Description { get; set; }

    }
}
