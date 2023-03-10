using TN.Modules.Buildings.Domain.ValueObjects;
using TN.Modules.IdentitiesDomain.Users.Exceptions;

namespace TN.Modules.IdentitiesDomain.Users.ValueObjects
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

        public static implicit operator string(Name value) => value.Value;
    }
}
