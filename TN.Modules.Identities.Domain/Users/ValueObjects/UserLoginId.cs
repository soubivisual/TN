using TN.Modules.Buildings.Shared.SharedKernel;

namespace TN.Modules.Identities.Domain.Users.ValueObjects
{
    public sealed class UserLoginId : ValueObjectBase<int>
    {
        public UserLoginId(int value) : base(value) { }

        public static implicit operator UserLoginId(int value) => new(value);

        public static implicit operator int(UserLoginId value) => value.Value;
    }
}
