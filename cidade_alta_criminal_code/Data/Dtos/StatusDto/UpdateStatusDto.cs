using cidade_alta_criminal_code.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace cidade_alta_criminal_code.Data.Dtos.StatusDto
{
    public class UpdateStatusDto
    {
        public string Name { get; set; }

        public virtual CriminalCode CriminalCode { get; set; }
    }
}
