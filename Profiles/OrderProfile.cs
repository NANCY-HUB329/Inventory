using AutoMapper;
using Inventory.Model;
using Inventory.Model.MyDTO;

namespace Inventory.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<AddOrdersDTO, Order>().ReverseMap();
            CreateMap<OrderResponseDTO, Order>().ReverseMap();
        }
    }
}
