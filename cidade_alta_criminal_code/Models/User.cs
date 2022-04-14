namespace cidade_alta_criminal_code.Models
{
    public class User
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public virtual ICollection<CriminalCode> CreateUsers { get; set; }

        public virtual ICollection<CriminalCode> UpdateUsers { get; set; }
    }
}
