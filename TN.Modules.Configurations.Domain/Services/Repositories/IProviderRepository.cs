using System.Linq.Expressions;
using TN.Modules.Configurations.Domain.Services.Entities;

namespace TN.Modules.Configurations.Domain.Providers.Repositories
{
    public interface IProviderRepository
    {
        Task<IReadOnlyList<Provider>> GetAllAsync();

        Task<Provider> GetAsync(int id);

        Task<Provider> FindAsync(Expression<Func<Provider, bool>> expression);

        Task AddAsync(Provider Provider);

        Task UpdateAsync(Provider Provider);
    }
}
