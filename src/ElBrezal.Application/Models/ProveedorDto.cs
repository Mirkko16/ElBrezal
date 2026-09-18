using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.Models
{
    public class ProveedorDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string? Direccion { get; set; }

        public int? LocalidadId { get; set; }

        public string? Localidad { get; set; }

        public string? CodigoPostal { get; set; }

        public string? Provincia { get; set; }

        public string? Telefono { get; set; }

        public string? CUIT { get; set; }

        public string? IngresosBrutos { get; set; }

        public string? Email { get; set; }

        public int? SituacionImpositivaId { get; set; }

        public string? SituacionImpositiva { get; set; }

        public string? Observacion { get; set; }
    }
}
