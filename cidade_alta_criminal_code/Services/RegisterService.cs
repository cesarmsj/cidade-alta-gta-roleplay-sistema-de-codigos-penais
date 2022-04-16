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
        private UserManager<IdentityUser<int>> _userManager;

        public RegisterService(IMapper mapper, UserManager<IdentityUser<int>> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public Result RegisterUser(CreateUserDto createDto)
        {
            User user = _mapper.Map<User>(createDto);
            IdentityUser<int> userIdentity = _mapper.Map<IdentityUser<int>>(user);
            Task<IdentityResult> identityResult = _userManager.CreateAsync(userIdentity, createDto.Password);

            if (identityResult.Result.Succeeded) return Result.Ok();
            return Result.Fail("Falha ao cadastrar o usuário");
        }
    }
}
