using Microsoft.EntityFrameworkCore;
using TN.Modules.Identities.Infrastructure.DataAccess;
using TN.Modules.Identities.Domain.Users.Aggregates;
using TN.Modules.Identities.Domain.Users.Repositories;
using System.Linq.Expressions;

namespace TN.Modules.Identities.Infrastructure.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly IdentitiesDbContext _context;

        public UserRepository(IdentitiesDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<User>> GetAllAsync()
        {
            var users = await _context.Users
                .AsNoTracking()
                .ToListAsync();

            return users;
        }

        public Task<User> GetAsync(int id)
            => _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(q => q.Id == id);

        public Task<User> FindAsync(Expression<Func<User, bool>> expression)
        => _context.Users
            .AsNoTracking()
            .Where(expression)
            .SingleOrDefaultAsync();

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
