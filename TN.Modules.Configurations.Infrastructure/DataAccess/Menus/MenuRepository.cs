using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TN.Modules.Configurations.Domain.Menus.Aggregates;
using TN.Modules.Configurations.Domain.Menus.Repositories;

namespace TN.Modules.Configurations.Infrastructure.DataAccess.Menus
{
    internal sealed class MenuRepository : IMenuRepository
    {
        private readonly ConfigurationsDbContext _context;

        public MenuRepository(ConfigurationsDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Menu>> GetAllAsync()
        {
            var menus = await _context.Menus
                .AsNoTracking()
                .ToListAsync();

            return menus;
        }

        public Task<Menu> GetAsync(int id)
        {
            return _context.Menus
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<Menu> FindAsync(Expression<Func<Menu, bool>> expression)
        {
            return _context.Menus
                .AsNoTracking()
                .Where(expression)
                .SingleOrDefaultAsync();
        }

        public async Task AddAsync(Menu menu)
        {
            await _context.Menus.AddAsync(menu);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Menu menu)
        {
            _context.Menus.Update(menu);
            await _context.SaveChangesAsync();
        }
    }
}
