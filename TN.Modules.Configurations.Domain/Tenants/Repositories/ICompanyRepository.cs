using System.Linq.Expressions;
using TN.Modules.Configurations.Domain.Tenants.Entities;

namespace TN.Modules.Configurations.Domain.Tenants.Repositories
{
    public interface ICompanyRepository
    {
        Task<IReadOnlyList<Company>> GetAllAsync();

        Task<Company> GetAsync(int id);

        Task<Company> FindAsync(Expression<Func<Company, bool>> expression);

        Task AddAsync(Company Company);

        Task UpdateAsync(Company Company);
    }
}
