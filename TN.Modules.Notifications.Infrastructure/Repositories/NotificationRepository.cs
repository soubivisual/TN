using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TN.Modules.Notifications.Domain.Notifications.Entities;
using TN.Modules.Notifications.Domain.Notifications.Repositories;

namespace TN.Modules.Notifications.Infrastructure.Repositories
{
    internal class NotificationRepository : INotificationRepository
    {
        public Task AddAsync(Notification notification)
        {
            throw new NotImplementedException();
        }

        public Task<Notification> GetAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
