using TransporteEscolar.Domain.Core;
namespace TransporteEscolar.Domain.Entities
{
    public class Horario : BaseEntity
    {
        public int HorarioId { get; set; }
        public int RutaId { get; set; }
        public string DiaSemana { get; set; } = string.Empty;
        public TimeSpan HoraSalida { get; set; }
        public TimeSpan HoraLlegadaEstimada { get; set; }
        public string TipoRuta { get; set; } = string.Empty;
        public bool Estado { get; set; } = true;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime? FechaModificacion { get; set; }

        // Relaciones
        public Ruta Ruta { get; set; } = null!;
    }
}