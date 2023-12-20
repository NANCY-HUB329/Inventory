using AutoMapper;
using Inventory.Model.MyDTO;
using Inventory.Model;

namespace Inventory.Profiles
{


    //  AutoMapper Profile for User mappings
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AddUserDTO, User>();
            

        }
    }
}

