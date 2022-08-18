using Bazart.API.DTO;
using Bazart.API.Services;
using Bazart.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bazart.API.Controllers
{
    [Route("api/event")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EventDto>> GetAll([FromQuery] string? like = null)
        {
            var events = _eventService.GetAllEvents();
            if (!string.IsNullOrWhiteSpace(like))
            {
                events = events.Where(d => d.Name.Contains(like));
            }

            return Ok(events);
        }
    }
}
