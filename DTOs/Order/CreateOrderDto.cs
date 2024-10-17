using backendPizzaria.Models;
using System.ComponentModel.DataAnnotations;

namespace backendPizzaria.DTOs.Order
{
    public class CreateOrderDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Table { get; set; }

        
        [Required]
        public string? Name { get; set; }

    }
}
