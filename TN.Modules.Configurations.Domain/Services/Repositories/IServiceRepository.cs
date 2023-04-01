using System.Linq.Expressions;
using TN.Modules.Configurations.Domain.Services.Aggregates;

namespace TN.Modules.Configurations.Domain.Services.Repositories
{
    public interface IServiceRepository
    {
        Task<IReadOnlyList<Service>> GetAllAsync();

        Task<Service> GetAsync(int id);

        Task<Service> FindAsync(Expression<Func<Service, bool>> expression);

        Task AddAsync(Service Service);

        Task UpdateAsync(Service Service);
    }
}
