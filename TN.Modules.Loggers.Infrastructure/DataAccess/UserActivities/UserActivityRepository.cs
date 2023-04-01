using Microsoft.EntityFrameworkCore;
using TN.Modules.Loggers.Domain.UserActivities.Aggregates;
using TN.Modules.Loggers.Domain.UserActivities.Repositories;

namespace TN.Modules.Loggers.Infrastructure.DataAccess.UserActivities
{
    internal sealed class UserActivityRepository : IUserActivityRepository
    {
        private readonly LoggersDbContext _context;

        public UserActivityRepository(LoggersDbContext context)
        {
            _context = context;
        }

        public Task<UserActivity> GetAsync(long id)
        {
            return _context.UserActivities
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
