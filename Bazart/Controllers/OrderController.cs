using Bazart.API.DTO;
using Bazart.API.Repository.IRepository;
using Bazart.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bazart.API.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _eventRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _eventRepository = orderRepository;
        }

        [HttpGet("{id:int}")]
        public ActionResult<OrderDto> GetOrderById(int id)
        {
            var orderById = _eventRepository.GetOrderById(id);
            return Ok(orderById);
        }
    }
}