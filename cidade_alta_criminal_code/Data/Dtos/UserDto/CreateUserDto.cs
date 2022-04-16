using cidade_alta_criminal_code.Models;
using System.ComponentModel.DataAnnotations;

namespace cidade_alta_criminal_code.Data.Dtos.UserDto
{
    public class CreateUserDto
    {
        [Required(ErrorMessage = "Informe o nome de usuário")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Informe uma senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirme a senha")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "As senhas não coincidem")]
        public string PasswordConfirmation { get; set; }

    }
}
