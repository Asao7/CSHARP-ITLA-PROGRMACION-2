namespace TransporteEscolar.Domain.Entities
{
    public class EstudianteRuta
    {
        public int Id { get; set; }
        public int EstudianteId { get; set; }
        public int RutaId { get; set; }
        public DateTime FechaAsignacion { get; set; }

        // Nuevas propiedades
        public DateTime? FechaModificacion { get; set; }  // nullable si puede ser null
        public string Turno { get; set; }

        // Relaciones
        public Estudiante Estudiante { get; set; }
        public Ruta Ruta { get; set; }
    }
}