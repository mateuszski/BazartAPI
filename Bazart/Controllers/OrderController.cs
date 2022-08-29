using Bazart.API.DTO;
using Bazart.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bazart.API.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _eventService;

        public OrderController(IOrderService orderService)
        {
            _eventService = orderService;
        }

        [HttpGet("{id:int}")]
        public ActionResult<OrderDto> GetOrderById( int id)
        {
            var orderById = _eventService.GetOrderById(id);
            return Ok(orderById);
        }
    }
}
