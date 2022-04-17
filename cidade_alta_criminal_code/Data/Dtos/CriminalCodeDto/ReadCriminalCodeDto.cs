using cidade_alta_criminal_code.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace cidade_alta_criminal_code.Data.Dtos.CriminalCodeDto
{
    public class ReadCriminalCodeDto
    {

        public int Id { get; set; }

        public string Name { get; set; }
        
        public string Description { get; set; }

        public decimal Penalty { get; set; }

        public int PrisionTime { get; set; }

        public int StatusID { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string CreateUserId { get; set; }

        public string UpdateUserId { get; set; }

        public ApplicationUser CreateUser { get; set; }

        public ApplicationUser UpdateUser { get; set; }
    }
}
