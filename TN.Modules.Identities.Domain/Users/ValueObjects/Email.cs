using System.Text.RegularExpressions;
using TN.Modules.Buildings.Shared.SharedKernel;

namespace TN.Modules.IdentitiesDomain.Users.ValueObjects
{
    public sealed class Email : ValueObjectBase<string>
    {
        public Email(string value) : base(value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(nameof(Email), "Email cannot be null or empty.");
            }

            if (!Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                throw new ArgumentException("Email is not valid.", nameof(Email));
            }
        }

        public static implicit operator Email(string value) => new(value);

        public static implicit operator string(Email value) => value.Value;
    }
}
