using Inventory.Model;
using Inventory.Model.MyDTO;

namespace Inventory.Profiles
{
    public class ProductProfile
    {

        public ProductProfile()
        {
            CreateMap<AddProductDTO, Product>().ReverseMap();

        }
    }
}

