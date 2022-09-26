using Bazart.API.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Bazart.API.Repository.IRepository
{
    public interface IOrderRepository
    {
        OrderDto GetOrderById([FromRoute] int id);
    }
}