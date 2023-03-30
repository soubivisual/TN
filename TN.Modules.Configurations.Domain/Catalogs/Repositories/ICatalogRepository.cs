using System.Linq.Expressions;
using TN.Modules.Configurations.Domain.Catalogs.Aggregates;
using TN.Modules.Configurations.Domain.Catalogs.ValueObjects;

namespace TN.Modules.Configurations.Domain.Catalogs.Repositories
{
    public interface ICatalogRepository
    {
        Task<IReadOnlyList<Catalog>> GetAllAsync();

        Task<IReadOnlyList<CatalogType>> GetTypesAsync();

        Task<Catalog> GetAsync(Guid id);

        Task<IReadOnlyList<Catalog>> GetByTypeAsync(CatalogType type);

        Task<Catalog> FindAsync(Expression<Func<Catalog, bool>> expression);

        Task AddAsync(Catalog catalog);

        Task UpdateAsync(Catalog catalog);
    }
}
