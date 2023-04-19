using TN.Modules.Buildings.Shared.SharedKernel;

namespace TN.Modules.Loggers.Domain.UserActivities.ValueObjects
{
    public sealed class UserActivityId : ValueObjectBase<long>
    {
        public UserActivityId(long value) : base(value) { }

        public static implicit operator UserActivityId(long value) => new(value);

        public static implicit operator long(UserActivityId value) => value.Value;
    }
}
