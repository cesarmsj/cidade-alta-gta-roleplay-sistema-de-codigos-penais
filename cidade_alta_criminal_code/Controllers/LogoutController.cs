using cidade_alta_criminal_code.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace cidade_alta_criminal_code.Controllers
{
    public class LogoutController : Controller
    {
        private LogoutService _logoutService;

        public LogoutController(LogoutService logoutService)
        {
            _logoutService = logoutService;
        }

        [HttpPost]
        public IActionResult Logout()
        {
            Result result = _logoutService.LogoutUser();
            if (result.IsFailed) return Unauthorized(result.Errors);
            return Ok(result.Successes);
        }
     }
}
