using TN.Modules.Loggers.Domain.UserActivities.Aggregates;

namespace TN.Modules.Loggers.Domain.UserActivities.Repositories
{
    public interface IUserActivityRepository
    {
        Task<UserActivity> GetAsync(long id);
    }
}
