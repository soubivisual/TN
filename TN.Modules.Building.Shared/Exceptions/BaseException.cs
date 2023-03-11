namespace TN.Modules.Building.Shared.Exceptions
{
    public abstract class BaseException : Exception
    {
        public BaseException(int httpStatus, string message) : this(httpStatus, httpStatus.ToString(), message) { }

        public BaseException(int httpStatus, string code, string message) : base(message)
        {
            HttpStatus = httpStatus;
            Errors = new List<Error>()
            {
                new Error(code, message, GetType().Name)
            };
        }

        public int HttpStatus { get; private set; }

        public List<Error> Errors { get; private set; }

        public record Error(string Code, string Message, string Type);

        public void Add(string code, string message)
            => Errors.Add(new Error(code, message, GetType().Name));

        public override string ToString()
        {
            if (Errors == null || !Errors.Any())
                return Message;

            return $"[{Errors.First().Code}] ({Errors.First().Type}) {Errors.First().Message}";
        }
    }
}
