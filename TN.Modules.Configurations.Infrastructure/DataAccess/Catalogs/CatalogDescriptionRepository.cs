using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TN.Modules.Configurations.Domain.Catalogs.Entities;
using TN.Modules.Configurations.Domain.Catalogs.Repositories;
using TN.Modules.Configurations.Domain.Catalogs.ValueObjects;

namespace TN.Modules.Configurations.Infrastructure.DataAccess.Catalogs
{
    internal sealed class CatalogDescriptionRepository : ICatalogDescriptionRepository
    {
        private readonly ConfigurationsDbContext _context;

        public CatalogDescriptionRepository(ConfigurationsDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<CatalogDescription>> GetAllAsync()
        {
            var catalogDescrilptions = await _context.CatalogDescriptions
                .AsNoTracking()
                .ToListAsync();

            return catalogDescrilptions;
        }

        public Task<CatalogDescription> GetAsync(int id)
        {
            return _context.CatalogDescriptions
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IReadOnlyList<CatalogDescription>> GetByTypeAsync(CatalogType type)
        {
            var catalogs = await _context.CatalogDescriptions
                .AsNoTracking()
                .Where(x => x.Type == type)
                .ToListAsync();

            return catalogs;
        }

        public Task<CatalogDescription> FindAsync(Expression<Func<CatalogDescription, bool>> expression)
        {
            return _context.CatalogDescriptions
                .AsNoTracking()
                .Where(expression)
                .SingleOrDefaultAsync();
        }

        public async Task AddAsync(CatalogDescription catalogDescription)
        {
            await _context.CatalogDescriptions.AddAsync(catalogDescription);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CatalogDescription catalogDescription)
        {
            _context.CatalogDescriptions.Update(catalogDescription);
            await _context.SaveChangesAsync();
        }
    }
}
