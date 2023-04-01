using TN.Modules.Loggers.Domain.TraceLogs.Aggregates;

namespace TN.Modules.Loggers.Domain.TraceLogs.Repositories
{
    public interface ITraceLogRepository
    {
        Task<TraceLog> GetAsync(long id);
    }
}
