using TN.Modules.Buildings.Shared.SharedKernel;

namespace TN.Modules.Loggers.Domain.ApplicationLogs.ValueObjects
{
    public sealed class ApplicationLogId : ValueObjectBase<long>
    {
        public ApplicationLogId(long value) : base(value) { }

        public static implicit operator ApplicationLogId(long value) => new(value);

        public static implicit operator long(ApplicationLogId value) => value.Value;
    }
}
