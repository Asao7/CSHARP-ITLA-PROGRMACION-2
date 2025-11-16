using Microsoft.EntityFrameworkCore;
using TransporteEscolar.Domain.Entities;
using TransporteEscolar.Infrastructure.Context;
using TransporteEscolar.Infrastructure.Interfaces;

namespace TransporteEscolar.Infrastructure.Repositories
{
    public class AsistenciaRepository : IAsistenciaRepository
    {
        private readonly ApplicationDbContext _context;

        public AsistenciaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Asistencia>> GetAllAsync()
        {
            return await _context.Asistencias.ToListAsync();
        }

        public async Task<Asistencia?> GetByIdAsync(int id)
        {
            return await _context.Asistencias.FindAsync(id);
        }

        public async Task<Asistencia> AddAsync(Asistencia asistencia)
        {
            _context.Asistencias.Add(asistencia);
            await _context.SaveChangesAsync();
            return asistencia;
        }

        public async Task<Asistencia> UpdateAsync(Asistencia asistencia)
        {
            asistencia.FechaModificacion = DateTime.Now;
            _context.Asistencias.Update(asistencia);
            await _context.SaveChangesAsync();
            return asistencia;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var asistencia = await _context.Asistencias.FindAsync(id);
            if (asistencia == null)
                return false;

            asistencia.Estado = false;
            asistencia.FechaModificacion = DateTime.Now;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
