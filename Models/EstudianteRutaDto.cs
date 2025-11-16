namespace TransporteEscolar.API.Models
{
    public class CreateEstudianteRutaDto
    {
        public int EstudianteId { get; set; }
        public int RutaId { get; set; }
        public string Turno { get; set; } = string.Empty;
    }

    public class UpdateEstudianteRutaDto
    {
        public int EstudianteId { get; set; }
        public int RutaId { get; set; }
        public string Turno { get; set; } = string.Empty;
    }

    public class EstudianteRutaDto
    {
        public int Id { get; set; }
        public int EstudianteId { get; set; }
        public string EstudianteNombre { get; set; } = string.Empty;
        public int RutaId { get; set; }
        public string RutaNombre { get; set; } = string.Empty;
        public string Turno { get; set; } = string.Empty;
    }
}
