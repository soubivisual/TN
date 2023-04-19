using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TN.Modules.Configurations.Domain.Tenants.Aggregates;
using TN.Modules.Configurations.Domain.Tenants.Repositories;

namespace TN.Modules.Configurations.Infrastructure.DataAccess.Tenants
{
    internal sealed class TenantRepository : ITenantRepository
    {
        private readonly ConfigurationsDbContext _context;

        public TenantRepository(ConfigurationsDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Tenant>> GetAllAsync()
        {
            var tenants = await _context.Tenants
                .AsNoTracking()
                .ToListAsync();

            return tenants;
        }

        public Task<Tenant> GetAsync(int id)
        {
            return _context.Tenants
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<Tenant> FindAsync(Expression<Func<Tenant, bool>> expression)
        {
            return _context.Tenants
                .AsNoTracking()
                .Where(expression)
                .SingleOrDefaultAsync();
        }

        public async Task AddAsync(Tenant tenant)
        {
            await _context.Tenants.AddAsync(tenant);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Tenant tenant)
        {
            _context.Tenants.Update(tenant);
            await _context.SaveChangesAsync();
        }
    }
}
