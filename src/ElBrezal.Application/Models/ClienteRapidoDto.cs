using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.Models
{
    public class ClienteRapidoDto
    {
        public string Nombre { get; set; } = string.Empty;

        public string? DNI { get; set; }

        public string? CUIT { get; set; }

        public string? Direccion { get; set; }

        public string? Telefono { get; set; }

        public int LocalidadId { get; set; }

        public int SituacionImpositivaId { get; set; }

        public int EstadoCuentaId { get; set; }

        public int VendedorId { get; set; }
    }
}
