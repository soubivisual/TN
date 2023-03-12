using TN.Modules.Notifications.Domain.Notifications.Entities;

namespace TN.Modules.Notifications.Domain.Notifications.Repositories
{
    public interface INotificationRepository
    {
        Task<Notification> GetAsync(long id);

        Task AddAsync(Notification notification);
    }
}
