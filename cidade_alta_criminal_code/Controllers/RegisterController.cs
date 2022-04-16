using cidade_alta_criminal_code.Data.Dtos.UserDto;
using cidade_alta_criminal_code.Services;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace cidade_alta_criminal_code.Controllers
{
    public class RegisterController : Controller
    {
        private RegisterService _registerService;
        private ILogger _logger;

        public RegisterController(RegisterService registerService, ILogger logger)
        {
            _registerService = registerService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult RegisterUser(CreateUserDto createDto)
        {
            Result result = _registerService.RegisterUser(createDto);
            if (result.IsFailed) {
                _logger.LogInformation("Houve uma falha ao tentar cadastrar novo usuário.");
                return RedirectToAction("Index", "Home");
            };
            _logger.LogInformation("O usuário criou uma nova conta com senha");
            return RedirectToAction("Index", "Home"); 
           
        }


    }
}
