namespace TransporteEscolar.Domain.Entities
{
    public class Pago
    {
        public int PagoId { get; set; }

        // FK a Estudiante
        public int EstudianteId { get; set; }
        public Estudiante Estudiante { get; set; } // navegación

        public string MesPago { get; set; } = null!;
        public int AnioPago { get; set; }
        public decimal MontoPagado { get; set; }
        public DateTime FechaPago { get; set; }
        public string MetodoPago { get; set; } = null!;

        // Estas pueden ser null
        public string? NumeroRecibo { get; set; }
        public string? Observaciones { get; set; }

        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }

        // Esta también puede ser null
        public DateTime? FechaModificacion { get; set; }
    }
}