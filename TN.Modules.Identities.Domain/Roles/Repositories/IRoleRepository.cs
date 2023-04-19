using System.Linq.Expressions;
using TN.Modules.Identities.Domain.Roles.Aggregates;

namespace TN.Modules.Identities.Domain.Roles.Repositories
{
    public interface IRoleRepository
    {
        Task<IReadOnlyList<Role>> GetAllAsync();

        Task<Role> GetAsync(int id);

        Task<Role> FindAsync(Expression<Func<Role, bool>> expression);

        Task AddAsync(Role role);

        Task UpdateAsync(Role role);
    }
}
