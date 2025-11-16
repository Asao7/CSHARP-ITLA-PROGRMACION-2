using TransporteEscolar.Domain.Core;

namespace TransporteEscolar.Domain.Entities
{
    public class Estudiante : BaseEntity
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
        public bool Estado { get; set; } = true;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime? FechaModificacion { get; set; }

        // Relaciones
        public ICollection<EstudianteRuta> EstudiantesRutas { get; set; } = new List<EstudianteRuta>();
        public ICollection<Pago> Pagos { get; set; } = new List<Pago>();
        public ICollection<Asistencia> Asistencias { get; set; } = new List<Asistencia>();
    }
}
