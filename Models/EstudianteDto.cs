namespace TransporteEscolar.API.Models
{
    public class EstudianteDto
    {
        public int EstudianteId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Matricula { get; set; } = string.Empty;
        public string Grado { get; set; } = string.Empty;
        public string? Seccion { get; set; }
        public string DireccionResidencia { get; set; } = string.Empty;
        public string TelefonoContacto { get; set; } = string.Empty;
        public string? NombrePadre { get; set; }
    }

    public class CreateEstudianteDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Matricula { get; set; } = string.Empty;
        public string Grado { get; set; } = string.Empty;
        public string? Seccion { get; set; }
        public string DireccionResidencia { get; set; } = string.Empty;
        public string TelefonoContacto { get; set; } = string.Empty;
        public string? NombrePadre { get; set; }
    }

    public class UpdateEstudianteDto  
    {
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Grado { get; set; } = string.Empty;
        public string? Seccion { get; set; }
        public string DireccionResidencia { get; set; } = string.Empty;
        public string TelefonoContacto { get; set; } = string.Empty;
        public string? NombrePadre { get; set; }
    }
}