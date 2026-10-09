namespace ElBrezal.Application.Models.Clientes
{
    public class SituacionImpositivaDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string? Abreviatura { get; set; }

        public decimal Porce { get; set; }
    }
}
