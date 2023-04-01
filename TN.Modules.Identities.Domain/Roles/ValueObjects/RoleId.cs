using TN.Modules.Buildings.Shared.SharedKernel;

namespace TN.Modules.Identities.Domain.Roles.ValueObjects
{
    public sealed class RoleId : ValueObjectBase<int>
    {
        public RoleId(int value) : base(value) { }

        public static implicit operator RoleId(int value) => new(value);

        public static implicit operator int(RoleId value) => value.Value;
    }
}
