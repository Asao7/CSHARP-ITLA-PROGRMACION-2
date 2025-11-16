using TransporteEscolar.Domain.Entities;

namespace TransporteEscolar.Application.Interfaces
{
    public interface IHorarioRepository
    {
        Task<IEnumerable<Horario>> GetAllAsync();
        Task<Horario> GetByIdAsync(int id);
        Task<Horario> AddAsync(Horario horario);
        Task<Horario> UpdateAsync(Horario horario);
        Task<bool> DeleteAsync(int id);
    }
}
