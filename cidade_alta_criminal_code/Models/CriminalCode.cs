using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace cidade_alta_criminal_code.Models
{
    public class CriminalCode
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [Precision(6,2)]
        public decimal Penalty { get; set; }

        public int PrisionTime  { get; set; }

        public int StatusID { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int CreateUserId { get; set; }

        public int UpdateUserId { get; set; }

        public virtual User CreateUser { get; set; }

        public virtual User UpdateUser { get; set; }



    }
}
