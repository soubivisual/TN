using TN.Modules.Buildings.Shared.SharedKernel;

namespace TN.Modules.Identities.Domain.Roles.ValueObjects
{
    public sealed class ClaimId : ValueObjectBase<int>
    {
        public ClaimId(int value) : base(value) { }

        public static implicit operator ClaimId(int value) => new(value);

        public static implicit operator int(ClaimId value) => value.Value;
    }
}
