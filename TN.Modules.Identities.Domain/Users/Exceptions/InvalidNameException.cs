using TN.Modules.Buildings.Shared.Exceptions;

namespace TN.Modules.Identities.Domain.Users.Exceptions
{
    internal sealed class InvalidNameException : BaseException
    {
        public string Name { get; }

        public InvalidNameException(string name) : base(400, $"Name: '{name}' is invalid.")
        {
            Name = name;
        }
    }
}
