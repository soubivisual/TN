using Microsoft.EntityFrameworkCore;
using TN.Modules.Logger.Domain.ApplicationLogs.Entities;
using TN.Modules.Logger.Domain.ApplicationLogs.Repositories;
using TN.Modules.Logger.Infrastructure.DataAccess;

namespace TN.Modules.Logger.Infrastructure.Repositories
{
    internal class ApplicationLogRepository : IApplicationLogRepository
    {
        private readonly LoggerDbContext _context;

        public ApplicationLogRepository(LoggerDbContext context)
        {
            _context = context;
        }

        public Task<ApplicationLog> GetAsync(long id)
            => _context.ApplicationLogs
                .AsNoTracking()
                .FirstOrDefaultAsync(q => q.Id == id);
    }
}
