using backendPizzaria.DALs.OrderItems;
using backendPizzaria.DALs.Product;
using backendPizzaria.DTOs.OrderItems;
using backendPizzaria.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backendPizzaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly OrderItemDAL _orderItemDAL;
        private readonly ProductDAL _productDAL;

        public OrderItemsController(OrderItemDAL orderItemsDAL, ProductDAL productDAL)
        {
            _orderItemDAL = orderItemsDAL;
            _productDAL = productDAL;
            
        }

        [HttpGet("Details/{orderId}")]
        public async Task<IActionResult> GetOrderDetails(int orderId)
        {
            var orderItems = await _orderItemDAL.GetOrderDetailsAsync(orderId);

            if (orderItems == null || !orderItems.Any())
            {
                return NotFound();
            }

            var orderItemDetails = orderItems.Select(item => new OrderItemsDTO
            {
                
                OrderId = item.OrderId,
                ProductId = item.Product.Id,
                Amount = item.Amount,
                
            }).ToList();

            return Ok(orderItemDetails);
        }

        [HttpPost("AddItem")]
        public async Task<ActionResult> AddOrderItem(OrderItemsDTO orderItemsDTO)
        {
            try
            {

                var product = await _productDAL.GetProductById(orderItemsDTO.ProductId);

                
                if (product == null)
                {
                    Console.WriteLine("Produto não encontrado.");
                    return NotFound("Produto não encontrado.");
                }

                
                Console.WriteLine($"Produto encontrado: {product.Description}");

                var orderItems = new OrderItemsModel
                {
                    OrderId = orderItemsDTO.OrderId,
                    ProductId = orderItemsDTO.ProductId,
                    Amount = orderItemsDTO.Amount,
                    ProductName = product.Description
                };

                await _orderItemDAL.AddAsync(orderItems);
                return Ok("Item adicionado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar item: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItem(int id)
        {
            var orderItem = await _orderItemDAL.GetOrderItemById(id);

            if (orderItem == null)
            {
                return NotFound("Item não encontrado!");

            }

            _orderItemDAL.DeleteOrderItem(id);
            return NoContent();


        }


    }
}
