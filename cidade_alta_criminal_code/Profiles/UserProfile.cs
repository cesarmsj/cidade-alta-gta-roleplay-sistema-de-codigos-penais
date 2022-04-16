using AutoMapper;
using cidade_alta_criminal_code.Data.Dtos.UserDto;
using cidade_alta_criminal_code.Models;
using Microsoft.AspNetCore.Identity;

namespace cidade_alta_criminal_code.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDto, User>();
            CreateMap<User, IdentityUser<int>>();
           //CreateMap<User, ReadUserDto>();
        }
       
    }
}
