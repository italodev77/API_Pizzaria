using backendPizzaria.DALs.Order;
using backendPizzaria.DTOs.Order;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace backendPizzaria.Controllers
{
    public class OrderController: ControllerBase
    {
        private readonly OrderDal _orderDal;

        public OrderController(OrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<ListAllOrdersDto>>> GetAllOrders()
        {
            var orders = await _orderDal.GetAllOrders();
            var ordersDto = orders.Select( o => new ListAllOrdersDto
            {
                Name = o.Name,
                Table = o.Table,
                Draft = o.Draft,
                Status = o.Status,

            }).ToList();

            return Ok(ordersDto);
        }
    }
}
