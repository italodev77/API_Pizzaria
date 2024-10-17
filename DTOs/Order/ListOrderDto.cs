using backendPizzaria.Models;
using System.ComponentModel.DataAnnotations;

namespace backendPizzaria.DTOs.Order
{
    public class ListOrderDto
    {
        
        [Required]
        public bool Status { get; set; } = false;

        [Required]
        public bool Draft { get; set; } = true;

    }
}
