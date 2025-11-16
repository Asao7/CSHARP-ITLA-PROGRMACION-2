using Microsoft.EntityFrameworkCore;
using TransporteEscolar.Domain.Entities;
using TransporteEscolar.Infrastructure.Context;
using TransporteEscolar.Infrastructure.Interfaces;

namespace TransporteEscolar.Infrastructure.Repositories
{
    public class ChoferRepository : IChoferRepository
    {
        private readonly ApplicationDbContext _context;

        public ChoferRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Chofer>> GetAllAsync()
        {
            return await _context.Choferes.ToListAsync();
        }

        public async Task<Chofer?> GetByIdAsync(int id)
        {
            return await _context.Choferes.FindAsync(id);
        }

        public async Task<Chofer> AddAsync(Chofer chofer)
        {
            _context.Choferes.Add(chofer);
            await _context.SaveChangesAsync();
            return chofer;
        }

        public async Task<Chofer> UpdateAsync(Chofer chofer)
        {
            chofer.FechaModificacion = DateTime.Now;
            _context.Choferes.Update(chofer);
            await _context.SaveChangesAsync();
            return chofer;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var chofer = await _context.Choferes.FindAsync(id);
            if (chofer == null)
                return false;

            chofer.Estado = false;
            chofer.FechaModificacion = DateTime.Now;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
