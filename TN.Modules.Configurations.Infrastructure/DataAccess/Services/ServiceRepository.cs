using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TN.Modules.Configurations.Domain.Services.Aggregates;
using TN.Modules.Configurations.Domain.Services.Repositories;

namespace TN.Modules.Configurations.Infrastructure.DataAccess.Services
{
    internal sealed class ServiceRepository : IServiceRepository
    {
        private readonly ConfigurationsDbContext _context;

        public ServiceRepository(ConfigurationsDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Service>> GetAllAsync()
        {
            var services = await _context.Services
                .AsNoTracking()
                .ToListAsync();

            return services;
        }

        public Task<Service> GetAsync(int id)
        {
            return _context.Services
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<Service> FindAsync(Expression<Func<Service, bool>> expression)
        {
            return _context.Services
                .AsNoTracking()
                .Where(expression)
                .SingleOrDefaultAsync();
        }

        public async Task AddAsync(Service service)
        {
            await _context.Services.AddAsync(service);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Service service)
        {
            _context.Services.Update(service);
            await _context.SaveChangesAsync();
        }
    }
}
