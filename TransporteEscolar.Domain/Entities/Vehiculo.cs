using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TransporteEscolar.Domain.Core;

namespace TransporteEscolar.Domain.Entities
{
    public class Vehiculo : BaseEntity
    {
        [Key]
        [Column("VehiculoId")]
        public int Id { get; set; }

        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }

        [Column("Anio")]
        public int Año { get; set; }

        public int Capacidad { get; set; }
        public bool Estado { get; set; }
        public int ChoferId { get; set; }

        // Propiedades de navegación
        public virtual Chofer Chofer { get; set; }
        public virtual ICollection<Ruta> Rutas { get; set; } = new List<Ruta>();

        public new DateTime? FechaCreacion { get; set; }
        public new DateTime? FechaModificacion { get; set; }
    }
}   