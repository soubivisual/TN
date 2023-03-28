using System.Linq.Expressions;
using TN.Modules.Identities.Domain.Users.Entities;

namespace TN.Modules.Identities.Domain.Users.Repositories
{
    public interface IUserRepository
    {
        Task<IReadOnlyList<User>> GetAllAsync();

        Task<User> GetAsync(int id);

        Task<User> FindAsync(Expression<Func<User, bool>> expression);

        Task AddAsync(User user);

        Task UpdateAsync(User user);
    }
}
