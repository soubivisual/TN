using TN.Modules.Buildings.Shared.SharedKernel;

namespace TN.Modules.Loggers.Domain.ApplicationLogs.ValueObjects
{
    public sealed class ApplicationLogType : ValueObjectBase<string>
    {
        public ApplicationLogType(string value) : base(value) { }

        public static ApplicationLogType Trace => new ApplicationLogType(nameof(Trace));
        public static ApplicationLogType Debug => new ApplicationLogType(nameof(Debug));
        public static ApplicationLogType Info => new ApplicationLogType(nameof(Info));
        public static ApplicationLogType Warn => new ApplicationLogType(nameof(Warn));
        public static ApplicationLogType Error => new ApplicationLogType(nameof(Error));
        public static ApplicationLogType Fatal => new ApplicationLogType(nameof(Fatal));

        public static implicit operator ApplicationLogType(string value) => new(value);

        public static implicit operator string(ApplicationLogType value) => value.Value;
    }
}
