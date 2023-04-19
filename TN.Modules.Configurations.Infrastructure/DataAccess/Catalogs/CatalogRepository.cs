using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TN.Modules.Configurations.Domain.Catalogs.Aggregates;
using TN.Modules.Configurations.Domain.Catalogs.Repositories;
using TN.Modules.Configurations.Domain.Catalogs.ValueObjects;

namespace TN.Modules.Configurations.Infrastructure.DataAccess.Catalogs
{
    internal sealed class CatalogRepository : ICatalogRepository
    {
        private readonly ConfigurationsDbContext _context;

        public CatalogRepository(ConfigurationsDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Catalog>> GetAllAsync()
        {
            var catalogs = await _context.Catalogs
                .AsNoTracking()
                .ToListAsync();

            return catalogs;
        }

        public async Task<IReadOnlyList<CatalogType>> GetTypesAsync()
        {
            var catalogTypes = await _context.Catalogs
                .AsNoTracking()
                .Select(x => x.Type)
                .Distinct()
                .ToListAsync();

            return catalogTypes;
        }

        public Task<Catalog> GetAsync(Guid id)
        {
            return _context.Catalogs
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IReadOnlyList<Catalog>> GetByTypeAsync(CatalogType type)
        {
            var catalogs = await _context.Catalogs
                .AsNoTracking()
                .Where(x => x.Type == type)
                .ToListAsync();

            return catalogs;
        }

        public Task<Catalog> FindAsync(Expression<Func<Catalog, bool>> expression)
        {
            return _context.Catalogs
                .AsNoTracking()
                .Where(expression)
                .SingleOrDefaultAsync();
        }

        public async Task AddAsync(Catalog catalog)
        {
            await _context.Catalogs.AddAsync(catalog);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Catalog catalog)
        {
            _context.Catalogs.Update(catalog);
            await _context.SaveChangesAsync();
        }
    }
}
