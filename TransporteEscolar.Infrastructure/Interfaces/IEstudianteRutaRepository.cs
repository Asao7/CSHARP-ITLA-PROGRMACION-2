using TransporteEscolar.Domain.Entities;

namespace TransporteEscolar.Infrastructure.Interfaces
{
    public interface IEstudianteRutaRepository
    {
        Task<IEnumerable<EstudianteRuta>> GetAllAsync();
        Task<EstudianteRuta?> GetByIdAsync(int id);
        Task<EstudianteRuta> AddAsync(EstudianteRuta entity);
        Task<EstudianteRuta> UpdateAsync(EstudianteRuta entity);
        Task<bool> DeleteAsync(int id);
    }
}
