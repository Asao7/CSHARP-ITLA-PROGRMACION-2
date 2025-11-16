using TransporteEscolar.Domain.Core;

namespace TransporteEscolar.Domain.Entities
{
    public class Asistencia : BaseEntity
    {
        public int AsistenciaId { get; set; }
        public int EstudianteId { get; set; }
        public int RutaId { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan HoraRegistro { get; set; }
        public string TipoRuta { get; set; } = string.Empty;
        public bool Presente { get; set; } = true;
        public string? Observaciones { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        // Relaciones
        public Estudiante Estudiante { get; set; } = null!;
        public Ruta Ruta { get; set; } = null!;
    }
}