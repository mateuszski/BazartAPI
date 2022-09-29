using Bazart.API.DTO;
using Bazart.API.Repository.IRepository;
using Bazart.API.Repository;
using Bazart.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bazart.API.Controllers
{
    [Route("api/event")]
    [ApiController]
    [AllowAnonymous]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        private readonly IUserRepository _userRepository;

        public EventController(IEventRepository eventRepository, IUserRepository userRepository)
        {
            _eventRepository = eventRepository;
            _userRepository = userRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EventDto>> GetAll([FromQuery] string? like = null)
        {
            var events = _eventRepository.GetAllEvents();
            if (!string.IsNullOrWhiteSpace(like))
            {
                events = events.Where(d => d.Name.Contains(like));
            }

            return Ok(events);
        }

        [HttpGet("{id:int}")]
        public ActionResult<IEnumerable<EventDto>> GetById([FromRoute] int id)
        {
            var eventById = _eventRepository.GetEventById(id);
            return Ok(eventById);
        }

        [HttpPost]
        public ActionResult CreateEvent([FromBody] CreateEventDto create)
        {
            var userClaims = User.Claims.Select(c => new
            {
                Type = c.Type,
                Value = c.Value
            });
            var userEmail = "";
            foreach (var item in userClaims)
            {
                userEmail = item.Value;
                break;
            }

            var userId = _userRepository.GetUserIdByEmail(userEmail);
            create.OwnerId = userId;
            var eventid = _eventRepository.CreateNewEvent(create);
            return Created($"/api/event{eventid}", null);
        }

        [HttpDelete("{id:int}")]
        public ActionResult RemoveEvent([FromRoute] int id)
        {
            _eventRepository.RemoveEvent(id);

            return NoContent();
        }

        [HttpPut("{id:int}")]
        public ActionResult UpdateEvent([FromRoute] int id, [FromBody] UpdateEventDto update)
        {
            _eventRepository.UpdateEvent(id, update);

            return Ok();
        }

        [HttpGet("latest")]
        public ActionResult<IEnumerable<EventDto>> LatestEvents()
        {
            var latestEvents = _eventRepository.GetLatestEvents();
            return Ok(latestEvents);
        }
    }
}