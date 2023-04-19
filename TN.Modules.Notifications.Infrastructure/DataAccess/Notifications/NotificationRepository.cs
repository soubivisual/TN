using Microsoft.EntityFrameworkCore;
using TN.Modules.Notifications.Domain.Notifications.Aggregates;
using TN.Modules.Notifications.Domain.Notifications.Repositories;

namespace TN.Modules.Notifications.Infrastructure.DataAccess.Notifications
{
    internal class NotificationRepository : INotificationRepository
    {
        private readonly NotificationsDbContext _context;

        public NotificationRepository(NotificationsDbContext context)
        {
            _context = context;
        }

        public Task<Notification> GetAsync(long id)
        {
            return _context.Notifications
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(Notification notification)
        {
            await _context.Notifications.AddAsync(notification);
            await _context.SaveChangesAsync();
        }
    }
}
