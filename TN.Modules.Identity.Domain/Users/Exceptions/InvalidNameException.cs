using TN.Modules.Building.Shared.Exceptions;

namespace TN.Modules.Identity.Domain.Users.Exceptions
{
    internal class InvalidNameException : BaseException
    {
        public string Name { get; }

        public InvalidNameException(string name) : base(400, $"Name: '{name}' is invalid.")
        {
            Name = name;
        }
    }
}
