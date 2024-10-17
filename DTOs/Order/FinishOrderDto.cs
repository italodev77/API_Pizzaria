using backendPizzaria.Models;
using System.ComponentModel.DataAnnotations;

namespace backendPizzaria.DTOs.Order
{
    public class FinishOrderDto
    {
        [Required]
        public bool Status { get; set; } 

    }
}
