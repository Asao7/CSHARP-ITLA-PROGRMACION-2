using TransporteEscolar.Domain.Entities;

namespace TransporteEscolar.Application.Interfaces
{
    public interface IRutaRepository
    {
        Task<IEnumerable<Ruta>> GetAllAsync();
        Task<Ruta> GetByIdAsync(int id);
        Task<Ruta> AddAsync(Ruta ruta);
        Task<Ruta> UpdateAsync(Ruta ruta);
        Task<bool> DeleteAsync(int id);
    }
}
