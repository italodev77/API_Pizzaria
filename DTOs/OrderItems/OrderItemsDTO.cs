using backendPizzaria.Models;

namespace backendPizzaria.DTOs.OrderItems
{
    public class OrderItemsDTO
    {
        public int Amount { get; set; }
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public int ProductId { get; set; }

    }
}
