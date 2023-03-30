using TN.Modules.Buildings.Shared.SharedKernel;
using TN.Modules.Identities.Domain.Users.Exceptions;

namespace TN.Modules.Identities.Domain.Users.ValueObjects
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
