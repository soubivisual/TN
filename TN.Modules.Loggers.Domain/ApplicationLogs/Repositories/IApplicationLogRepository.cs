using TN.Modules.Loggers.Domain.ApplicationLogs.Entities;

namespace TN.Modules.Loggers.Domain.ApplicationLogs.Repositories
{
    public interface IApplicationLogRepository
    {
        Task<ApplicationLog> GetAsync(long id);
    }
}
