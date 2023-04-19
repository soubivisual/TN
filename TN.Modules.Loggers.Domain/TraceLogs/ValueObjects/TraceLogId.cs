using TN.Modules.Buildings.Shared.SharedKernel;

namespace TN.Modules.Loggers.Domain.TraceLogs.ValueObjects
{
    public sealed class TraceLogId : ValueObjectBase<long>
    {
        public TraceLogId(long value) : base(value) { }
        
        public static implicit operator TraceLogId(long value) => new(value);

        public static implicit operator long(TraceLogId value) => value.Value;
    }
}
