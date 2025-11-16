namespace TransporteEscolar.API.Models
{
    public class AsistenciaDto
    {
        public int AsistenciaId { get; set; }
        public int EstudianteId { get; set; }
        public int RutaId { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan HoraRegistro { get; set; }
        public string TipoRuta { get; set; } = string.Empty;
        public bool Presente { get; set; }
        public string? Observaciones { get; set; }
    }

    public class CreateAsistenciaDto
    {
        public int EstudianteId { get; set; }
        public int RutaId { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan HoraRegistro { get; set; }
        public string TipoRuta { get; set; } = string.Empty;
        public bool Presente { get; set; }
        public string? Observaciones { get; set; }
    }

    public class UpdateAsistenciaDto
    {
        public TimeSpan HoraRegistro { get; set; }
        public bool Presente { get; set; }
        public string? Observaciones { get; set; }
    }
}
