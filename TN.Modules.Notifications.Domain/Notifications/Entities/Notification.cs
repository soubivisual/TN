using TN.Modules.Buildings.Shared.SharedKernel;
using TN.Modules.Notifications.Domain.Notifications.ValueObjects;

namespace TN.Modules.Notifications.Domain.Notifications.Entities
{
    public sealed class Notification : EntityBase<NotificationId>
    {
        public int TenantId { get; private set; }

        public int UserId { get; private set; }

        public Guid TypeId { get; private set; }

        public Guid StatusId { get; private set; }

        public short Priority { get; private set; }

        public string Title { get; private set; }

        public string Text { get; private set; }

        public string CallbackUrl { get; private set; }

        public bool Read { get; private set; }

        public DateTime Date { get; private set; }

        public DateTime? ReadDate { get; private set; }

        public DateTime? ExpirationDate { get; set; }

        public Guid CoreProcessId { get; set; }

        public Notification() : base(default) { }

        public Notification(NotificationId id, int tenantId, int userId, Guid typeId, Guid statusId, short priority, string title, string text, string callbackUrl, bool read, DateTime date, DateTime? readDate, DateTime? expirationDate, Guid coreProcessId) : base(id)
        {
            TenantId = tenantId;
            UserId = userId;
            TypeId = typeId;
            StatusId = statusId;
            Priority = priority;
            Title = title;
            Text = text;
            CallbackUrl = callbackUrl;
            Read = read;
            Date = date;
            ReadDate = readDate;
            ExpirationDate = expirationDate;
            CoreProcessId = coreProcessId;
        }
    }
}
