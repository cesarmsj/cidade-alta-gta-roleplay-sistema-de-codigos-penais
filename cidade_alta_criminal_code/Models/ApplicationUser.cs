using Microsoft.AspNetCore.Identity;

namespace cidade_alta_criminal_code.Models
{
    public class ApplicationUser : IdentityUser
    {
        //public string Id { get; set; }

        //public string UserName { get; set; }

        //public string Password { get; set; }

        public virtual ICollection<CriminalCode> CreateUsers { get; set; }

        public virtual ICollection<CriminalCode> UpdateUsers { get; set; }

    }
}
