using AutoMapper;
using Bazart.API.DTO;
using Bazart.Models;

namespace Bazart.API
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
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserDataUpdateDto, User>().ReverseMap();
            CreateMap<UserFirstRegistarationDto, User>().ReverseMap();
        }
    }
}