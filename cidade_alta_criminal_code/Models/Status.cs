﻿namespace cidade_alta_criminal_code.Models
{
    public class Status
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual CriminalCode CriminalCode { get; set; }

    }
}
