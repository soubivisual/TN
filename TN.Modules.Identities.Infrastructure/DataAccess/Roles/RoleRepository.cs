using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TN.Modules.Identities.Domain.Roles.Aggregates;
using TN.Modules.Identities.Domain.Roles.Repositories;

namespace TN.Modules.Identities.Infrastructure.DataAccess.Roles
{
    internal sealed class RoleRepository : IRoleRepository
    {
        private readonly IdentitiesDbContext _context;

        public RoleRepository(IdentitiesDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Role>> GetAllAsync()
        {
            var roles = await _context.Roles
                .AsNoTracking()
                .ToListAsync();

            return roles;
        }

        public Task<Role> GetAsync(int id)
        {
            return _context.Roles
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<Role> FindAsync(Expression<Func<Role, bool>> expression)
        {
            return _context.Roles
                .AsNoTracking()
                .Where(expression)
                .SingleOrDefaultAsync();
        }

        public async Task AddAsync(Role role)
        {
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Role role)
        {
            _context.Roles.Update(role);
            await _context.SaveChangesAsync();
        }
    }
}
