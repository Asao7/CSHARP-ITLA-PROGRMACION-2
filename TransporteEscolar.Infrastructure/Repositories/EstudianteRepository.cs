using Microsoft.EntityFrameworkCore;
using TransporteEscolar.Infrastructure.Interfaces;
using TransporteEscolar.Domain.Entities;
using TransporteEscolar.Infrastructure.Context;

namespace TransporteEscolar.Infrastructure.Repositories
{
    public class EstudianteRepository : IEstudianteRepository
    {
        private readonly ApplicationDbContext _context;

        public EstudianteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Estudiante>> GetAllAsync()
        {
            return await _context.Estudiantes
                .Where(e => e.Estado)
                .OrderBy(e => e.Apellido)
                .ThenBy(e => e.Nombre)
                .ToListAsync();
        }

        public async Task<Estudiante?> GetByIdAsync(int id)
        {
            return await _context.Estudiantes
                .Include(e => e.EstudiantesRutas)
                    .ThenInclude(er => er.Ruta)
                .Include(e => e.Pagos)
                .Include(e => e.Asistencias)
                .FirstOrDefaultAsync(e => e.EstudianteId == id && e.Estado);
        }

        public async Task<Estudiante> AddAsync(Estudiante estudiante)
        {
            _context.Estudiantes.Add(estudiante);
            await _context.SaveChangesAsync();
            return estudiante;
        }

        public async Task<Estudiante> UpdateAsync(Estudiante estudiante)
        {
            estudiante.FechaModificacion = DateTime.Now;
            _context.Entry(estudiante).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return estudiante;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante == null) return false;

            // Soft delete
            estudiante.Estado = false;
            estudiante.FechaModificacion = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Estudiantes.AnyAsync(e => e.EstudianteId == id && e.Estado);
        }
    }
}