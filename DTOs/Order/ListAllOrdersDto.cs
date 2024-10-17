using backendPizzaria.Models;
using System.ComponentModel.DataAnnotations;

namespace backendPizzaria.DTOs.Order
{
    public class ListAllOrdersDto
    {
        [Required]
        public string? Name { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Table { get; set; }

        [Required]
        public bool Status { get; set; }

        [Required]
        public bool Draft { get; set; }

    }
}
