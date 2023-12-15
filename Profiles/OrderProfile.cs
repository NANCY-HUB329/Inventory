using Inventory.Model;
using Inventory.Model.MyDTO;




namespace Inventory.Profiles
{
    public class OrderProfile
    {
        public OrderProfile()
        {
            CreateMap<AddOrdersDTO, Order>().ReverseMap();
            CreateMap<OrderResponseDTO, Order>().ReverseMap();

        }
    }
}
