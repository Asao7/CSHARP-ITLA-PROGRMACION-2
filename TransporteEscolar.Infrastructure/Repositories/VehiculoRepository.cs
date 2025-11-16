using Microsoft.EntityFrameworkCore;
using TransporteEscolar.Domain.Entities;
using TransporteEscolar.Infrastructure.Context;
using TransporteEscolar.Infrastructure.Interfaces;

namespace TransporteEscolar.Infrastructure.Repositories
{
    public class VehiculoRepository : IVehiculoRepository
    {
        private readonly ApplicationDbContext _context;

        public VehiculoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Vehiculo>> GetAllAsync()
        {
            return await _context.Vehiculos
                .Include(v => v.Chofer)
                .ToListAsync();
        }

        public async Task<Vehiculo?> GetByIdAsync(int id)
        {
            return await _context.Vehiculos
                .Include(v => v.Chofer)
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<Vehiculo> AddAsync(Vehiculo vehiculo)
        {
            _context.Vehiculos.Add(vehiculo);
            await _context.SaveChangesAsync();
            return vehiculo;
        }

        public async Task<Vehiculo> UpdateAsync(Vehiculo vehiculo)
        {
            _context.Vehiculos.Update(vehiculo);
            await _context.SaveChangesAsync();
            return vehiculo;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.Vehiculos.FindAsync(id);
            if (existing == null) return false;

            _context.Vehiculos.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
