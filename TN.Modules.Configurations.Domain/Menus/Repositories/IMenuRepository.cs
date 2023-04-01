using System.Linq.Expressions;
using TN.Modules.Configurations.Domain.Menus.Aggregates;

namespace TN.Modules.Configurations.Domain.Menus.Repositories
{
    public interface IMenuRepository
    {
        Task<IReadOnlyList<Menu>> GetAllAsync();

        Task<Menu> GetAsync(int id);

        Task<Menu> FindAsync(Expression<Func<Menu, bool>> expression);

        Task AddAsync(Menu Menu);

        Task UpdateAsync(Menu Menu);
    }
}
