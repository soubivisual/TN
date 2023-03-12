using TN.Modules.Buildings.Domain.ValueObjects;

namespace TN.Modules.IdentitiesDomain.Users.ValueObjects
{
    public sealed class UserId : ValueObjectBase<int>
    {
        public UserId(int value) : base(value)
        {

        }

        public static implicit operator UserId(int value) => new(value);

        public static implicit operator int(UserId value) => value.Value;
    }
}
