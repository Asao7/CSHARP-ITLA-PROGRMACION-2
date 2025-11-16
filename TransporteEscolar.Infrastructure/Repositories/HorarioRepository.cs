using Microsoft.EntityFrameworkCore;
using TransporteEscolar.Application.Interfaces;
using TransporteEscolar.Domain.Entities;
using TransporteEscolar.Infrastructure.Context;

namespace TransporteEscolar.Infrastructure.Repositories
{
    public class HorarioRepository : IHorarioRepository
    {
        private readonly ApplicationDbContext _context;

        public HorarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Horario> AddAsync(Horario horario)
        {
            _context.Horarios.Add(horario);
            await _context.SaveChangesAsync();
            return horario;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var horario = await _context.Horarios.FindAsync(id);
            if (horario == null) return false;
            _context.Horarios.Remove(horario);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Horario>> GetAllAsync()
        {
            return await _context.Horarios.ToListAsync();
        }

        public async Task<Horario> GetByIdAsync(int id)
        {
            return await _context.Horarios.FindAsync(id);
        }

        public async Task<Horario> UpdateAsync(Horario horario)
        {
            _context.Horarios.Update(horario);
            await _context.SaveChangesAsync();
            return horario;
        }
    }
}
