namespace TransporteEscolar.Domain.Core
{
    public abstract class BaseEntity
    {
        public bool Estado { get; set; } = true;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime? FechaModificacion { get; set; }
    }
}
