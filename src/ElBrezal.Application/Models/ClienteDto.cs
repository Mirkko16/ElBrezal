namespace ElBrezal.Application.Models
{
    public class ClienteDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string? DNI { get; set; }

        public string? CUIT { get; set; }

        public string? IngresosBrutos { get; set; }

        public string? Direccion { get; set; }

        public int LocalidadId { get; set; }

        public string Localidad { get; set; } = string.Empty;

        public string CodigoPostal { get; set; } = string.Empty;

        public string Provincia { get; set; } = string.Empty;

        public string? Telefono { get; set; }
       
        public string? Email { get; set; }

        public int SituacionImpositivaId { get; set; }

        public string SituacionImpositiva { get; set; } = string.Empty;

        public int EstadoCuentaId { get; set; }

        public string EstadoCuenta { get; set; } = string.Empty;

        public int? VendedorId { get; set; }

        public string? Vendedor { get; set; }

        public string? Observacion { get; set; }

    }
}
