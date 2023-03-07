using TN.Modules.Logger.Domain.ApplicationLogs.Entities;

namespace TN.Modules.Logger.Domain.ApplicationLogs.Repositories
{
    public interface IApplicationLogRepository
    {
        Task<ApplicationLog> GetAsync(long id);
    }
}
