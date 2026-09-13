using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.Models
{
    public class VendedorDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string? Direccion { get; set; }

        public string? Telefono { get; set; }

        public int? LocalidadId { get; set; }

        public string? Localidad { get; set; }

        public string? Email { get; set; }
    }
}
