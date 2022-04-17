using cidade_alta_criminal_code.Data.Requests;
using cidade_alta_criminal_code.Models;
using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace cidade_alta_criminal_code.Services
{
    public class LoginService
    {
        //private SignInManager<IdentityUser<int>> _signInManager;
        private SignInManager<ApplicationUser> _signInManager;
        private TokenService _tokenService;

        //public LoginService(SignInManager<IdentityUser<int>> signInManager, TokenService tokenService)
        public LoginService(SignInManager<ApplicationUser> signInManager, TokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public Result SignInUser(LoginRequest request)
        {
            var resultIdentity = _signInManager.PasswordSignInAsync(request.UserName, request.Password, false, false);

            if (resultIdentity.Result.Succeeded)
            {
                var identityUser = _signInManager
                    .UserManager
                    .Users
                    .FirstOrDefault(usuario =>
                    usuario.NormalizedUserName == request.UserName.ToUpper());
                Token token = _tokenService.CreateToken(identityUser);
                return Result.Ok().WithSuccess(token.Value);
            }
            return Result.Fail("Login falhou");
        }
    }
}
