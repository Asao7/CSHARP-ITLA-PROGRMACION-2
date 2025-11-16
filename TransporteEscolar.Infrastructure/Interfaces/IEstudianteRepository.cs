using TransporteEscolar.Domain.Entities;

namespace TransporteEscolar.Infrastructure.Interfaces
{
    public interface IEstudianteRepository
    {
        Task<IEnumerable<Estudiante>> GetAllAsync();
        Task<Estudiante?> GetByIdAsync(int id);
        Task<Estudiante> AddAsync(Estudiante estudiante);
        Task<Estudiante> UpdateAsync(Estudiante estudiante);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}