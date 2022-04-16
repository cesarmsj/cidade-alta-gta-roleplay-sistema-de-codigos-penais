using System.ComponentModel.DataAnnotations;

namespace cidade_alta_criminal_code.Data.Requests
{
    public class LoginRequest
    {
        [Required]
        public string Username { get; set; }   

        [Required]
        public string Password { get; set; }
    }
}
