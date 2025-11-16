using Microsoft.EntityFrameworkCore;
using TransporteEscolar.Domain.Entities;
using TransporteEscolar.Infrastructure.Context;
using TransporteEscolar.Infrastructure.Interfaces;

namespace TransporteEscolar.Infrastructure.Repositories
{
    public class EstudianteRutaRepository : IEstudianteRutaRepository
    {
        private readonly ApplicationDbContext _context;

        public EstudianteRutaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EstudianteRuta>> GetAllAsync()
        {
            return await _context.EstudiantesRutas
                .Include(er => er.Estudiante)
                .Include(er => er.Ruta)
                .ToListAsync();
        }

        public async Task<EstudianteRuta?> GetByIdAsync(int id)
        {
            return await _context.EstudiantesRutas
                .Include(er => er.Estudiante)
                .Include(er => er.Ruta)
                .FirstOrDefaultAsync(er => er.Id == id);
        }

        public async Task<EstudianteRuta> AddAsync(EstudianteRuta entity)
        {
            _context.EstudiantesRutas.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<EstudianteRuta> UpdateAsync(EstudianteRuta entity)
        {
            _context.EstudiantesRutas.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.EstudiantesRutas.FindAsync(id);
            if (existing == null) return false;

            _context.EstudiantesRutas.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
