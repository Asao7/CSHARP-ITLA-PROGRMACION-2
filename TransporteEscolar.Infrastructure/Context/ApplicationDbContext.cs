using Microsoft.EntityFrameworkCore;
using TransporteEscolar.Domain.Entities;

namespace TransporteEscolar.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // DbSets (representan las tablas)
        public DbSet<Chofer> Choferes { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Ruta> Rutas { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<EstudianteRuta> EstudiantesRutas { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Asistencia> Asistencias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de relaciones y restricciones

            // Chofer - Vehiculo (1 a muchos)
            modelBuilder.Entity<Vehiculo>()
                .HasOne(v => v.Chofer)
                .WithMany(c => c.Vehiculos)
                .HasForeignKey(v => v.ChoferId)
                .OnDelete(DeleteBehavior.SetNull);

            // Vehiculo - Ruta (1 a muchos)
            modelBuilder.Entity<Ruta>()
                .HasOne(r => r.Vehiculo)
                .WithMany(v => v.Rutas)
                .HasForeignKey(r => r.VehiculoId)
                .OnDelete(DeleteBehavior.SetNull);

            // Ruta - Horario (1 a muchos)
            modelBuilder.Entity<Horario>()
                .HasOne(h => h.Ruta)
                .WithMany(r => r.Horarios)
                .HasForeignKey(h => h.RutaId)
                .OnDelete(DeleteBehavior.Cascade);

            // Estudiante - EstudianteRuta (1 a muchos)
            modelBuilder.Entity<EstudianteRuta>()
                .HasOne(er => er.Estudiante)
                .WithMany(e => e.EstudiantesRutas)
                .HasForeignKey(er => er.EstudianteId)
                .OnDelete(DeleteBehavior.Cascade);

            // Ruta - EstudianteRuta (1 a muchos)
            modelBuilder.Entity<EstudianteRuta>()
                .HasOne(er => er.Ruta)
                .WithMany(r => r.EstudiantesRutas)
                .HasForeignKey(er => er.RutaId)
                .OnDelete(DeleteBehavior.Cascade);

            // Estudiante - Pago (1 a muchos)
            modelBuilder.Entity<Pago>()
                .HasOne(p => p.Estudiante)
                .WithMany(e => e.Pagos)
                .HasForeignKey(p => p.EstudianteId)
                .OnDelete(DeleteBehavior.Cascade);

            // Estudiante - Asistencia (1 a muchos)
            modelBuilder.Entity<Asistencia>()
                .HasOne(a => a.Estudiante)
                .WithMany(e => e.Asistencias)
                .HasForeignKey(a => a.EstudianteId)
                .OnDelete(DeleteBehavior.Cascade);

            // Ruta - Asistencia (1 a muchos)
            modelBuilder.Entity<Asistencia>()
                .HasOne(a => a.Ruta)
                .WithMany(r => r.Asistencias)
                .HasForeignKey(a => a.RutaId)
                .OnDelete(DeleteBehavior.NoAction);

            // Configuración de precisión decimal
            modelBuilder.Entity<Ruta>()
                .Property(r => r.DistanciaKm)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Pago>()
                .Property(p => p.MontoPagado)
                .HasPrecision(10, 2);
        }
    }
}