using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.Models
{
    public class AlicuotaIVADto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public decimal Porcentaje { get; set; }
    }
}
