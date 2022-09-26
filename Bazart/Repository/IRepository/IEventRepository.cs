using Bazart.API.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Bazart.API.Repository.IRepository
{
    public interface IEventRepository
    {
        IEnumerable<EventDto> GetAllEvents();

        EventDto GetEventById([FromRoute] int id);

        int CreateNewEvent(CreateEventDto create);

        void RemoveEvent(int id);

        void UpdateEvent(int id, UpdateEventDto update);
    }
}