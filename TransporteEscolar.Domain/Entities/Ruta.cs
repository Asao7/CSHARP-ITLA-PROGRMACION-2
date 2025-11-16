using System;
using System.Collections.Generic;

namespace TransporteEscolar.Domain.Entities
{
    public class Ruta
    {
        public int RutaId { get; set; }

        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public string PuntoInicio { get; set; } = null!;
        public string PuntoFin { get; set; } = null!;
        public decimal? DistanciaKm { get; set; } // Puede ser null
        public int? VehiculoId { get; set; } // FK a Vehiculo
        public Vehiculo? Vehiculo { get; set; } // navegación
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }

        // Relaciones
        public ICollection<Horario> Horarios { get; set; } = new List<Horario>();
        public ICollection<EstudianteRuta> EstudiantesRutas { get; set; } = new List<EstudianteRuta>();
        public ICollection<Asistencia> Asistencias { get; set; } = new List<Asistencia>();
    }
}
