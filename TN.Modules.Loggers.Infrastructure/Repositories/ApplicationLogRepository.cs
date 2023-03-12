using Microsoft.EntityFrameworkCore;
using TN.Modules.Loggers.Domain.ApplicationLogs.Entities;
using TN.Modules.Loggers.Domain.ApplicationLogs.Repositories;
using TN.Modules.Loggers.Infrastructure.DataAccess;

namespace TN.Modules.Loggers.Infrastructure.Repositories
{
    internal class ApplicationLogRepository : IApplicationLogRepository
    {
        private readonly LoggersDbContext _context;

        public ApplicationLogRepository(LoggersDbContext context)
        {
            _context = context;
        }

        public Task<ApplicationLog> GetAsync(long id)
            => _context.ApplicationLogs
                .AsNoTracking()
                .FirstOrDefaultAsync(q => q.Id == id);
    }
}
