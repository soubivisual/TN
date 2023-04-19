using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TN.Modules.Configurations.Domain.Providers.Repositories;
using TN.Modules.Configurations.Domain.Services.Entities;

namespace TN.Modules.Configurations.Infrastructure.DataAccess.Providers
{
    internal sealed class ProviderRepository : IProviderRepository
    {
        private readonly ConfigurationsDbContext _context;

        public ProviderRepository(ConfigurationsDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Provider>> GetAllAsync()
        {
            var providers = await _context.Providers
                .AsNoTracking()
                .ToListAsync();

            return providers;
        }

        public Task<Provider> GetAsync(int id)
        {
            return _context.Providers
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<Provider> FindAsync(Expression<Func<Provider, bool>> expression)
        {
            return _context.Providers
                .AsNoTracking()
                .Where(expression)
                .SingleOrDefaultAsync();
        }

        public async Task AddAsync(Provider provider)
        {
            await _context.Providers.AddAsync(provider);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Provider provider)
        {
            _context.Providers.Update(provider);
            await _context.SaveChangesAsync();
        }
    }
}
