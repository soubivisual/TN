using TN.Modules.Building.Domain.ValueObjects;
using TN.Modules.Logger.Domain.ApplicationLogs.Exceptions;

namespace TN.Modules.Logger.Domain.ApplicationLogs.ValueObjects
{
    public sealed class ApplicationLogType : ValueObjectBase<string>
    {
        private static readonly HashSet<string> AllowedValues = new()
        {
            "Trace", "Debug", "Info", "Warn", "Error", "Fatal", "Off"
        };

        public ApplicationLogType(string value) : base(value)
        {
            if (!AllowedValues.Contains(value))
            {
                throw new UnsupportedApplicationLogTypeException(value);
            }
        }

        public static implicit operator ApplicationLogType(string value) => new(value);
    }
}
