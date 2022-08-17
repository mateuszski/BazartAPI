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

    }
}
