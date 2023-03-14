using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TN.Modules.Configurations.Domain.Catalogs.Entities;
using TN.Modules.Configurations.Domain.Catalogs.Repositories;
using TN.Modules.Configurations.Infrastructure.DataAccess;

namespace TN.Modules.Configurations.Infrastructure.Repositories
{
    internal class CatalogRepository : ICatalogRepository
    {
        private readonly ConfigurationsDbContext _context;

        public CatalogRepository(ConfigurationsDbContext context)
        {
            _context = context;
        }

        public Task<Catalog> GetAsync(Guid id)
            => _context.Catalogs
                .AsNoTracking()
                .FirstOrDefaultAsync(q => q.Id == id);

        public Task<Catalog> FindAsync(Expression<Func<Catalog, bool>> expression)
            => _context.Catalogs
                .AsNoTracking()
                //.AsQueryable()
                .Where(expression)
                .SingleOrDefaultAsync();

        public async Task AddAsync(Catalog user)
        {
            await _context.Catalogs.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Catalog user)
        {
            _context.Catalogs.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
