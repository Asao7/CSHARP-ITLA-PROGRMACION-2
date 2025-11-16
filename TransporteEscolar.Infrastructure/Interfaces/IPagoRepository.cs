using TransporteEscolar.Domain.Entities;

namespace TransporteEscolar.Application.Interfaces
{
    public interface IPagoRepository
    {
        Task<IEnumerable<Pago>> GetAllAsync();
        Task<Pago> GetByIdAsync(int id);
        Task<Pago> AddAsync(Pago pago);
        Task<Pago> UpdateAsync(Pago pago);
        Task<bool> DeleteAsync(int id);
    }
}
