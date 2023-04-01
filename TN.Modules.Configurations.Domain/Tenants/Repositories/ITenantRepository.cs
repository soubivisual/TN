using System.Linq.Expressions;
using TN.Modules.Configurations.Domain.Tenants.Aggregates;

namespace TN.Modules.Configurations.Domain.Tenants.Repositories
{
    public interface ITenantRepository
    {
        Task<IReadOnlyList<Tenant>> GetAllAsync();

        Task<Tenant> GetAsync(int id);

        Task<Tenant> FindAsync(Expression<Func<Tenant, bool>> expression);

        Task AddAsync(Tenant Tenant);

        Task UpdateAsync(Tenant Tenant);
    }
}
