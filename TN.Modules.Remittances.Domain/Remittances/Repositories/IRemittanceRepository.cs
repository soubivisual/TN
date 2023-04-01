using TN.Modules.Remittances.Domain.Remittances.Aggregates;

namespace TN.Modules.Remittances.Domain.Remittances.Repositories
{
    public interface IRemittanceRepository
    {
        Task<Remittance> GetAsync(long id);

        Task AddAsync(Remittance remittance);
    }
}
