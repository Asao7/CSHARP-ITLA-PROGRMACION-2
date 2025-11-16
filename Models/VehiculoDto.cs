namespace TransporteEscolar.API.Models
{
    public class CreateVehiculoDto
    {
        public string Placa { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public int Año { get; set; }
        public int Capacidad { get; set; }
        public int ChoferId { get; set; }
    }

    public class UpdateVehiculoDto
    {
        public string Placa { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public int Año { get; set; }
        public int Capacidad { get; set; }
        public int ChoferId { get; set; }
    }

    public class VehiculoDto
    {
        public int Id { get; set; }
        public string Placa { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public int Año { get; set; }
        public int Capacidad { get; set; }
        public int ChoferId { get; set; }
        public string ChoferNombre { get; set; } = string.Empty;
    }
}
