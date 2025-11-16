using TransporteEscolar.Domain.Core;

namespace TransporteEscolar.Domain.Entities
{
    public class Chofer : BaseEntity
    {
        public int ChoferId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Cedula { get; set; } = string.Empty;
        public string? Telefono { get; set; }
        public string LicenciaConducir { get; set; } = string.Empty;
        public DateTime FechaContratacion { get; set; }
        public bool Estado { get; set; } = true;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime? FechaModificacion { get; set; }

        // Relaciones
        public ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
    }
}