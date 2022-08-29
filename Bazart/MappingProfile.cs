using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Bazart.API.DTO;
using Bazart.Models;

namespace Bazart.Utility
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<CreateProductDto, Product>();
            CreateMap<CreateEventDto, Event>();
            CreateMap<Event, EventDto>();
            CreateMap<Order, OrderDto>();
                //.ForMember(o => o.UserId, u => u.MapFrom(k => k.User.Id));
            CreateMap<OrderDto, Order>();
        }
    }
}
