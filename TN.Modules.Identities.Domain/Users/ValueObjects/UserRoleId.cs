using TN.Modules.Buildings.Shared.SharedKernel;

namespace TN.Modules.Identities.Domain.Users.ValueObjects
{
    public sealed class UserRoleId : ValueObjectBase<int>
    {
        public UserRoleId(int value) : base(value) { }

        public static implicit operator UserRoleId(int value) => new(value);

        public static implicit operator int(UserRoleId value) => value.Value;
    }
}
