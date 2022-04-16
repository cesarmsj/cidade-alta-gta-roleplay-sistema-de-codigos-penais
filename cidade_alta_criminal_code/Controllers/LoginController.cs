using cidade_alta_criminal_code.Data.Requests;
using cidade_alta_criminal_code.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace cidade_alta_criminal_code.Controllers
{
    public class LoginController : Controller
    {
        private LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(LoginRequest request)
        {
            Result result = _loginService.SignInUser(request);
            if(result.IsFailed) return Unauthorized(result.Errors);
            return Ok(result.Successes);
        }
    }
}
