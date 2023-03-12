using System.Linq.Expressions;
using TN.Modules.Configurations.Domain.Catalogs.Entities;

namespace TN.Modules.Configurations.Domain.Catalogs.Repositories
{
    public interface ICatalogRepository
    {
        Task<Catalog> GetAsync(Guid id);

        Task<Catalog> FindAsync(Expression<Func<Catalog, bool>> expression);

        Task AddAsync(Catalog catalog);

        Task UpdateAsync(Catalog catalog);
    }
}
