using TN.Modules.Buildings.Domain.ValueObjects;

namespace TN.Modules.Notifications.Domain.Notifications.ValueObjects
{
    public sealed class NotificationId : ValueObjectBase<long>
    {
        public NotificationId(long value) : base(value)
        {

        }

        public static implicit operator NotificationId(long value) => new(value);

        public static implicit operator long(NotificationId value) => value.Value;
    }
}
