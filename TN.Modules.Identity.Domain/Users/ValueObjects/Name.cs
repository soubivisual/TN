using TN.Modules.Building.Domain.ValueObjects;
using TN.Modules.Identity.Domain.Users.Exceptions;

namespace TN.Modules.Identity.Domain.Users.ValueObjects
{
    public sealed class Name : ValueObjectBase<string>
    {
        public Name(string value) : base(value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length is > 100 or < 2)
            {
                throw new InvalidNameException(value);
            }
        }

        public static implicit operator Name(string value) => new(value);
    }
}
