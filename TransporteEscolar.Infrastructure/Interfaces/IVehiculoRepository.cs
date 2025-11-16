using TransporteEscolar.Domain.Entities;

namespace TransporteEscolar.Infrastructure.Interfaces
{
    public interface IVehiculoRepository
    {
        Task<IEnumerable<Vehiculo>> GetAllAsync();
        Task<Vehiculo?> GetByIdAsync(int id);
        Task<Vehiculo> AddAsync(Vehiculo vehiculo);
        Task<Vehiculo> UpdateAsync(Vehiculo vehiculo);
        Task<bool> DeleteAsync(int id);
    }
}
