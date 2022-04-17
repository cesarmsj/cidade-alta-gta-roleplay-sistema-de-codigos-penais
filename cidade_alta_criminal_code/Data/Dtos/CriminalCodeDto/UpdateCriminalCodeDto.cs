using cidade_alta_criminal_code.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace cidade_alta_criminal_code.Data.Dtos.CriminalCodeDto
{
    public class UpdateCriminalCodeDto
    {
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Name { get; set; }

        
        public string Description { get; set; }

        [Required(ErrorMessage = "O campo penalidade é obrigatório")]
        [Precision(6, 2)]
        public decimal Penalty { get; set; }

        [Required(ErrorMessage = "O campo tempo de prisão é obrigatório")]
        public int PrisionTime { get; set; }

        [Required(ErrorMessage = "O campo de status é obrigatório")]
        public int StatusId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string CreateUserId { get; set; }

        public string UpdateUserId { get; set; }

    }
}
