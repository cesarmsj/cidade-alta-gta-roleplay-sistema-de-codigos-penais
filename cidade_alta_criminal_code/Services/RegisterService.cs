using AutoMapper;
using cidade_alta_criminal_code.Data.Dtos.UserDto;
using cidade_alta_criminal_code.Models;
using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace cidade_alta_criminal_code.Services
{
    public class RegisterService
    {
        private IMapper _mapper;
        //private UserManager<IdentityUser<int>> _userManager;
        private UserManager<ApplicationUser> _userManager;

       // public RegisterService(IMapper mapper, UserManager<IdentityUser<int>> userManager)
        public RegisterService(IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public Result RegisterUser(CreateUserDto createDto)
        {
            ApplicationUser user = _mapper.Map<ApplicationUser>(createDto);
            
            Task<IdentityResult> identityResult = _userManager.CreateAsync(user, createDto.Password);

            if (identityResult.Result.Succeeded) return Result.Ok();
            return Result.Fail("Falha ao cadastrar o usuário");
        }
    }
}
