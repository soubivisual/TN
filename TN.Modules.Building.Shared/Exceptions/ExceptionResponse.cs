namespace TN.Modules.Building.Shared.Exceptions
{
    public sealed class ExceptionResponse
    {
        public ExceptionResponse(Guid coreProcessId, List<Error> errors, long timestamp)
        {
            CoreProcessId = coreProcessId;
            Errors = errors;
            Timestamp = timestamp;
        }

        public Guid CoreProcessId { get; private set; }

        public List<Error> Errors { get; private set; }

        public long Timestamp { get; private set; }

        public class Error
        {
            public Error(string code, string message, string type)
            {
                Code = code;
                Message = message;
                Type = type;
            }

            public string Code { get; private set; }

            public string Message { get; private set; }

            public string Type { get; private set; }

            public override string ToString() => $"[{Code}] ({Type}) {Message}";
        }
    }
}
