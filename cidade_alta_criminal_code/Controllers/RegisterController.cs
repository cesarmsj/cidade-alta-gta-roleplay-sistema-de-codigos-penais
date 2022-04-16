using cidade_alta_criminal_code.Data.Dtos.UserDto;
using cidade_alta_criminal_code.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace cidade_alta_criminal_code.Controllers
{
    public class RegisterController : Controller
    {
        private RegisterService _registerService;

        public RegisterController(RegisterService registerService)
        {
            _registerService = registerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterUser(CreateUserDto createDto)
        {
            Result result = _registerService.RegisterUser(createDto);
            if (result.IsFailed) return StatusCode(500);
            return Ok();
        }


    }
}
