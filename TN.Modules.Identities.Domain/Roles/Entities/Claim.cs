using TN.Modules.Buildings.Shared.SharedKernel;
using TN.Modules.Identities.Domain.Roles.ValueObjects;

namespace TN.Modules.Identities.Domain.Roles.Entities
{
    public sealed class Claim : EntityBase<ClaimId>
    {
        public string Type { get; private set; }

        public string Value { get; private set; }

        public Claim() : base(default) { }

        public Claim(ClaimId id, string type, string value) : base(id)
        {
            Type = type;
            Value = value;
        }
    }
}
