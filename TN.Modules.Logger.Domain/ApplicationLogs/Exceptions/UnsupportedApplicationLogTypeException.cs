using TN.Modules.Building.Shared.Exceptions;

namespace TN.Modules.Logger.Domain.ApplicationLogs.Exceptions
{
    internal class UnsupportedApplicationLogTypeException : BaseException
    {
        public string Type { get; set; }

        public UnsupportedApplicationLogTypeException(string type) : base(400, $"Application Log Type: '{type}' is unsupported.")
        {
            Type = type;
        }
    }
}
