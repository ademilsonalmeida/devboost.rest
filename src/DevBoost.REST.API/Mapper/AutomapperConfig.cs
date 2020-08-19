using AutoMapper;
using DevBoost.REST.API.Models;
using DevBoost.REST.API.ViewModels;
using DevBoost.REST.Domain.Models;

namespace DevBoost.REST.API.Mapper
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<CreateUserViewModel, User>();
            CreateMap<EditUserViewModel, User>();            
        }
    }
}
