namespace TransporteEscolar.API.Models
{
    public class ChoferDto
    {
        public int ChoferId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Cedula { get; set; } = string.Empty;
        public string? Telefono { get; set; }
        public string LicenciaConducir { get; set; } = string.Empty;
        public DateTime FechaContratacion { get; set; }
    }

    public class CreateChoferDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Cedula { get; set; } = string.Empty;
        public string? Telefono { get; set; }
        public string LicenciaConducir { get; set; } = string.Empty;
        public DateTime FechaContratacion { get; set; }
    }

    public class UpdateChoferDto
    {
        public string? Telefono { get; set; }
        public string LicenciaConducir { get; set; } = string.Empty;
    }
}
