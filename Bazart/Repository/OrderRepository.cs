using AutoMapper;
using Bazart.API.DTO;
using Bazart.API.Exceptions;
using Bazart.API.Repository.IRepository;
using Bazart.DataAccess.Data;

namespace Bazart.API.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BazartDbContext _dbContext;
        private readonly IMapper _mapper;

        public OrderRepository(BazartDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public OrderDto GetOrderById(int id)
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