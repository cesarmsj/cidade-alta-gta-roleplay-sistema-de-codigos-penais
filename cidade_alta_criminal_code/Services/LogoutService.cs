using cidade_alta_criminal_code.Models;
using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace cidade_alta_criminal_code.Services
{
    public class LogoutService
    {
        //private SignInManager<IdentityUser<int>> _signInManager;
        private SignInManager<ApplicationUser> _signInManager;

        //public LogoutService(SignInManager<IdentityUser<int>> signInManager)
        public LogoutService(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public Result LogoutUser()
        {
            var resultIdentity = _signInManager.SignOutAsync();
            if (resultIdentity.IsCompletedSuccessfully) return Result.Ok();
            return Result.Fail("Logout falhou");
        }
    }
}
