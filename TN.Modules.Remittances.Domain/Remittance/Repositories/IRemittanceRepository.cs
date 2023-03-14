using TN.Modules.Remittances.Domain.Remittances.Entities;

namespace TN.Modules.Remittances.Domain.Remittances.Repositories
{
    public interface IRemittanceRepository
    {
        Task<Remittance> GetAsync(long id);

        Task AddAsync(Remittance remittance);
    }
}
