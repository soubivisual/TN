using Microsoft.EntityFrameworkCore;
using TN.Modules.IdentitiesInfrastructure.DataAccess;
using TN.Modules.IdentitiesDomain.Users.Entities;
using TN.Modules.IdentitiesDomain.Users.Repositories;
using System.Linq.Expressions;

namespace TN.Modules.IdentitiesInfrastructure.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly IdentitiesDbContext _context;

        public UserRepository(IdentitiesDbContext context)
        {
            _context = context;
        }

        public Task<User> GetAsync(int id)
            => _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(q => q.Id == id);

        public Task<User> FindAsync(Expression<Func<User, bool>> expression)
        => _context.Users
            .AsNoTracking()
            //.AsQueryable()
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
