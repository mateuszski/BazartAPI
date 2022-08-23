using AutoMapper;
using Bazart.API.DTO;
using Bazart.DataAccess.Data;
using AutoMapper;
using Bazart.API.DTO;
using Bazart.API.Exceptions;
using Bazart.Controllers;
using Bazart.DataAccess.Data;
using Bazart.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bazart.API.Services
{
    public class EventService : IEventService
    {
        private readonly BazartDbContext _dbContext;
        private readonly IMapper _mapper;

        public EventService(BazartDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<EventDto> GetAllEvents()
        {
            var events = _dbContext
                .Events
                .Include(p => p.Owner)
                .ToList();

            var eventsDto = _mapper.Map<List<EventDto>>(events);

            return eventsDto;
        }

        public EventDto GetEventById([FromRoute] int id)
        {
            var eventsId = _dbContext
                .Events
                .Include(p => p.Owner)
                .FirstOrDefault(p => p.Id == id);
            if (eventsId is null)
            {
                throw new NotFoundException("Event not found.");
            }

            var eventsIdDto = _mapper.Map<EventDto>(eventsId);
            return eventsIdDto;
        }

        public int CreateNewEvent(CreateEventDto create)
        {
            var events = _mapper.Map<Event>(create);
            _dbContext.Events.Add(events);
            _dbContext.SaveChanges();
            return events.Id;
        }

        public void RemoveEvent(int id)
        {
            var isRemoveEvent = _dbContext.Events.FirstOrDefault(p => p.Id == id);
            if (isRemoveEvent is null)
            {
                throw new NotFoundException("Event not found");
            }
            _dbContext.Events.Remove(isRemoveEvent);
            _dbContext.SaveChanges();
        }

        public void UpdateEvent(int id, UpdateEventDto update)
        {
            var eventUpdateData = _dbContext.Events.FirstOrDefault(e => e.Id == id);
            if (eventUpdateData is null)
            {
                throw new NotFoundException("Product not found");
            }

            eventUpdateData.Name = update.Name;
            eventUpdateData.Description = update.Description;
            eventUpdateData.Adress = update.Adress;
            eventUpdateData.ImageUrl = update.ImageUrl;
            _dbContext.SaveChanges();
        }

    }
}
