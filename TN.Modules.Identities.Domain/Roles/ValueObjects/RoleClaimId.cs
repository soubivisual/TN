using TN.Modules.Buildings.Shared.SharedKernel;

namespace TN.Modules.Identities.Domain.Roles.ValueObjects
{
    public sealed class RoleClaimId : ValueObjectBase<int>
    {
        public RoleClaimId(int value) : base(value) { }

        public static implicit operator RoleClaimId(int value) => new(value);

        public static implicit operator int(RoleClaimId value) => value.Value;
    }
}
