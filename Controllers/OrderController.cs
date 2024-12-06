using backendPizzaria.DALs.Order;
using backendPizzaria.DALs.Product;
using backendPizzaria.DTOs.Order;
using backendPizzaria.DTOs.Product;
using backendPizzaria.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace backendPizzaria.Controllers
{
    

    [ApiController]
    [Route("/orders")]
    public class OrderController: ControllerBase
    {
        private readonly OrderDAL _orderDal;

        public OrderController(OrderDAL orderDal)
        {
            _orderDal = orderDal;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<ListAllOrdersDto>>> GetAllOrders()
        {
            var orders = await _orderDal.GetAllOrders();
            var ordersDto = orders.Select( table => new ListAllOrdersDto
            {
                Name = table.Name,
                Table = table.Table,
                Draft = table.Draft,
                Status = table.Status,

            }).ToList();

            return Ok(ordersDto);
        }

        [HttpPost]
        public async Task<ActionResult> AddOrder(CreateOrderDto createOrderDto)
        {
            try
            {
                var order = new OrderModel
                {
                    Table = createOrderDto.Table,
                    Name = createOrderDto.Name,
                };

                await _orderDal.AddOrder(order);

                if (order.Id == 0)
                {
                    return BadRequest("Falha ao gerar o ID do pedido.");
                }

                
                return Ok(new { id = order.Id }); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPut("{id}")]
        public async Task<ActionResult> FinishOrder(int id, FinishOrderDto finishOrderDto)
        {
            var order = await _orderDal.GetOrderById(id);

            if(order == null)
            {
                return NotFound("Pedido não encontrado!");
            }

            order.Status = finishOrderDto.Status;

            await _orderDal.AddOrder(order);
            return NoContent();
           

        }
    }
}
