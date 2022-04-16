using System.ComponentModel.DataAnnotations;

namespace cidade_alta_criminal_code.Data.Requests
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Informe o nome de usuário")]
        public string UserName { get; set; }   

        [Required(ErrorMessage = "Informe a senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
