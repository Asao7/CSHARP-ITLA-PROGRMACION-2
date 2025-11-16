using Microsoft.EntityFrameworkCore;
using TransporteEscolar.Application.Interfaces;
using TransporteEscolar.Domain.Entities;
using TransporteEscolar.Infrastructure.Context;

namespace TransporteEscolar.Infrastructure.Repositories
{
    public class RutaRepository : IRutaRepository
    {
        private readonly ApplicationDbContext _context;

        public RutaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Ruta> AddAsync(Ruta ruta)
        {
            _context.Rutas.Add(ruta);
            await _context.SaveChangesAsync();
            return ruta;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var ruta = await _context.Rutas.FindAsync(id);
            if (ruta == null) return false;
            _context.Rutas.Remove(ruta);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Ruta>> GetAllAsync()
        {
            return await _context.Rutas.ToListAsync();
        }

        public async Task<Ruta> GetByIdAsync(int id)
        {
            return await _context.Rutas.FindAsync(id);
        }

        public async Task<Ruta> UpdateAsync(Ruta ruta)
        {
            _context.Rutas.Update(ruta);
            await _context.SaveChangesAsync();
            return ruta;
        }
    }
}
