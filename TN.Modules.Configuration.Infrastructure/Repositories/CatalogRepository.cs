using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TN.Modules.Configuration.Domain.Catalogs.Entities;
using TN.Modules.Configuration.Domain.Catalogs.Repositories;
using TN.Modules.Configuration.Infrastructure.DataAccess;

namespace TN.Modules.Configuration.Infrastructure.Repositories
{
    internal class CatalogRepository : ICatalogRepository
    {
        private readonly ConfigurationDbContext _context;

        public CatalogRepository(ConfigurationDbContext context)
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
