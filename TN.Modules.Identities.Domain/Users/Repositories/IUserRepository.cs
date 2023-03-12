using System.Linq.Expressions;
using TN.Modules.IdentitiesDomain.Users.Entities;

namespace TN.Modules.IdentitiesDomain.Users.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(int id);

        Task<User> FindAsync(Expression<Func<User, bool>> expression);

        Task AddAsync(User user);

        Task UpdateAsync(User user);
    }
}
