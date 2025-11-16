using TransporteEscolar.Domain.Entities;
using TransporteEscolar.Infrastructure.Context;
using TransporteEscolar.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TransporteEscolar.Infrastructure.Repositories
{
    public class PagoRepository : IPagoRepository
    {
        private readonly ApplicationDbContext _context;

        public PagoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pago>> GetAllAsync() =>
            await _context.Pagos.ToListAsync();

        public async Task<Pago> GetByIdAsync(int id) =>
            await _context.Pagos.FindAsync(id);

        public async Task<Pago> AddAsync(Pago pago)
        {
            _context.Pagos.Add(pago);
            await _context.SaveChangesAsync();
            return pago;
        }

        public async Task<Pago> UpdateAsync(Pago pago)
        {
            _context.Pagos.Update(pago);
            await _context.SaveChangesAsync();
            return pago;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var pago = await _context.Pagos.FindAsync(id);
            if (pago == null) return false;
            _context.Pagos.Remove(pago);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
