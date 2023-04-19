using Microsoft.EntityFrameworkCore;
using TN.Modules.Loggers.Domain.ApplicationLogs.Aggregates;
using TN.Modules.Loggers.Domain.ApplicationLogs.Repositories;

namespace TN.Modules.Loggers.Infrastructure.DataAccess.ApplicationLogs
{
    internal sealed class ApplicationLogRepository : IApplicationLogRepository
    {
        private readonly LoggersDbContext _context;

        public ApplicationLogRepository(LoggersDbContext context)
        {
            _context = context;
        }

        public Task<ApplicationLog> GetAsync(long id)
        {
            return _context.ApplicationLogs
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
