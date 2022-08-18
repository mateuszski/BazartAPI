using Bazart.API.DTO;
using Bazart.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bazart.API.Services
{
    public interface IEventService
    {
        IEnumerable<EventDto> GetAllEvents();
    }
}
