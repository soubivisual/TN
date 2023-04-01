using System.Linq.Expressions;
using TN.Modules.Configurations.Domain.Catalogs.Entities;
using TN.Modules.Configurations.Domain.Catalogs.ValueObjects;

namespace TN.Modules.Configurations.Domain.Catalogs.Repositories
{
    public interface ICatalogDescriptionRepository
    {
        Task<IReadOnlyList<CatalogDescription>> GetAllAsync();

        Task<CatalogDescription> GetAsync(int id);

        Task<IReadOnlyList<CatalogDescription>> GetByTypeAsync(CatalogType type);

        Task<CatalogDescription> FindAsync(Expression<Func<CatalogDescription, bool>> expression);

        Task AddAsync(CatalogDescription catalog);

        Task UpdateAsync(CatalogDescription catalog);
    }
}
