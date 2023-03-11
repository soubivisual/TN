using TN.Modules.Building.Domain.ValueObjects;

namespace TN.Modules.Logger.Domain.ApplicationLogs.ValueObjects
{
    public sealed class ApplicationLogId : ValueObjectBase<long>
    {
        public ApplicationLogId(long value) : base(value)
        {

        }

        public static implicit operator ApplicationLogId(long value) => new(value);

        public static implicit operator long(ApplicationLogId value) => value.Value;
    }
}
