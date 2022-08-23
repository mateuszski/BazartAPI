using Bazart.API.DTO;
using Bazart.API.Services;
using Bazart.Models;
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
        [HttpGet("{id:int}")]
        public ActionResult<IEnumerable<EventDto>> GetById([FromRoute] int id)
        {
            var eventById = _eventService.GetEventById(id);
            return Ok(eventById);
        }

        [HttpPost]
        public ActionResult CreateEvent([FromBody] CreateEventDto create)
        {
            var eventid = _eventService.CreateNewEvent(create);
            return Created($"/api/event{eventid}", null);
        }

        [HttpDelete("{id:int}")]
        public ActionResult RemoveEvent([FromRoute] int id)
        {
            _eventService.RemoveEvent(id);

            return NoContent();
        }

        [HttpPut("{id:int}")]
        public ActionResult UpdateEvent([FromRoute] int id, [FromBody] UpdateEventDto update)
        {
            _eventService.UpdateEvent(id, update);

            return Ok();
        }
    }
}
