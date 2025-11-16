using TransporteEscolar.Domain.Entities;

namespace TransporteEscolar.Infrastructure.Interfaces
{
    public interface IAsistenciaRepository
    {
        Task<IEnumerable<Asistencia>> GetAllAsync();
        Task<Asistencia?> GetByIdAsync(int id);
        Task<Asistencia> AddAsync(Asistencia asistencia);
        Task<Asistencia> UpdateAsync(Asistencia asistencia);
        Task<bool> DeleteAsync(int id);
    }
}
