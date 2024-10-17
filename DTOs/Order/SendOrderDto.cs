using backendPizzaria.Models;
using System.ComponentModel.DataAnnotations;

namespace backendPizzaria.DTOs.Order
{
    public class SendOrderDto
    {
        [Required]
        public bool Draft { get; set; }

    }
}
