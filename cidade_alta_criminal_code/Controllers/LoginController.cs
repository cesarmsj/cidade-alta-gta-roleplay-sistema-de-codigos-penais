using cidade_alta_criminal_code.Data.Requests;
using cidade_alta_criminal_code.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace cidade_alta_criminal_code.Controllers
{
    public class LoginController : Controller
    {
        private LoginService _loginService;
        private ILogger _logger;

        public LoginController(LoginService loginService, ILogger logger)
        {
            _loginService = loginService;
            _logger = logger;
        }

        public IActionResult Index(String msg)
        {
            ViewBag.Message = msg;

            return View();
        }

        [HttpPost]
        public IActionResult SignInUser(LoginRequest request)
        {
            Result result = _loginService.SignInUser(request);
            //if(result.IsFailed) return Unauthorized(result.Errors);
            //return Ok(result.Successes);

            if (result.IsFailed)
            {
                _logger.LogInformation("Falha no login");
                return RedirectToAction("Index", "Login", new { msg = "fail"});
            };
            _logger.LogInformation("Login Efetuado com Sucesso");
            return RedirectToAction("Index", "CriminalCode");
        }
    }
}
