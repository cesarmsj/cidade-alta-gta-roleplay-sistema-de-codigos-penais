using cidade_alta_criminal_code.Models;
using System.ComponentModel.DataAnnotations;

namespace cidade_alta_criminal_code.Data.Dtos.UserDto
{
    public class CreateUserDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "As senhas não coincidem")]
        public string PasswordConfirmation { get; set; }

    }
}
