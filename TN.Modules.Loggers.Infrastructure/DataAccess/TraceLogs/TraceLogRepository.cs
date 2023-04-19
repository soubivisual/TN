using Microsoft.EntityFrameworkCore;
using TN.Modules.Loggers.Domain.TraceLogs.Aggregates;
using TN.Modules.Loggers.Domain.TraceLogs.Repositories;

namespace TN.Modules.Loggers.Infrastructure.DataAccess.TraceLogs
{
    internal sealed class TraceLogRepository : ITraceLogRepository
    {
        private readonly LoggersDbContext _context;

        public TraceLogRepository(LoggersDbContext context)
        {
            _context = context;
        }

        public Task<TraceLog> GetAsync(long id)
        {
            return _context.TraceLogs
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
