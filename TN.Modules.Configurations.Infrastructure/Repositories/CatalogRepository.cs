using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TN.Modules.Configurations.Domain.Catalogs.Entities;
using TN.Modules.Configurations.Domain.Catalogs.Repositories;
using TN.Modules.Configurations.Domain.Catalogs.ValueObjects;
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
                .Select(q => q.Type)
                .Distinct()
                .ToListAsync();

            return catalogTypes;
        }

        public Task<Catalog> GetAsync(Guid id)
            => _context.Catalogs
                .AsNoTracking()
                .FirstOrDefaultAsync(q => q.Id == id);

        public async Task<IReadOnlyList<Catalog>> GetByTypeAsync(CatalogType type)
        {
            var response = await _context.Catalogs
                .AsNoTracking()
                .Where(q => q.Type == type)
                .ToListAsync();

            return response;
        }

        public Task<Catalog> FindAsync(Expression<Func<Catalog, bool>> expression)
            => _context.Catalogs
                .AsNoTracking()
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
