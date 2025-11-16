using TransporteEscolar.Domain.Entities;

namespace TransporteEscolar.Infrastructure.Interfaces
{
    public interface IChoferRepository
    {
        Task<IEnumerable<Chofer>> GetAllAsync();
        Task<Chofer?> GetByIdAsync(int id);
        Task<Chofer> AddAsync(Chofer chofer);
        Task<Chofer> UpdateAsync(Chofer chofer);
        Task<bool> DeleteAsync(int id);
    }
}
