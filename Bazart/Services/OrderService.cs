using AutoMapper;
using Bazart.API.DTO;
using Bazart.API.Exceptions;
using Bazart.DataAccess.Data;
using Bazart.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bazart.API.Services
{
    public class OrderService : IOrderService
    {
        private readonly BazartDbContext _dbContext;
        private readonly IMapper _mapper;

        public OrderService(BazartDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public OrderDto GetOrderById([FromRoute] int id)
        {
            var orderId = _dbContext
                .Orders
                //.Include(o => o.User)
                .FirstOrDefault(o => o.Id == id);
            if (orderId is null)
            {
                throw new NotFoundException("Order not found.");
            }

            var orderIdDto = _mapper.Map<OrderDto>(orderId);
            return orderIdDto;
        }
    }
}
