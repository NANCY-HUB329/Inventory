// ProductProfile.cs
using AutoMapper;
using Inventory.Model;
using Inventory.Model.MyDTO;

namespace Inventory.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductResponseDTO>();
            CreateMap<AddProductDTO, Product>();
            CreateMap<Product, AddProductDTO>(); // If you need to map in the reverse direction
        }
    }
}
