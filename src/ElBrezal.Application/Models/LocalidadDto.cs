using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.Models
{
    public class LocalidadDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string CodigoPostal { get; set; } = string.Empty;

        public int ProvinciaId { get; set; }

        public string Provincia { get; set; } = string.Empty;
    }
}
