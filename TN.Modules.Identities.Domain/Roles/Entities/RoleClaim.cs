using TN.Modules.Buildings.Shared.SharedKernel;
using TN.Modules.Identities.Domain.Roles.ValueObjects;

namespace TN.Modules.Identities.Domain.Roles.Entities
{
    public sealed class RoleClaim : EntityBase<RoleClaimId>
    {
        public RoleId RoleId { get; private set; }

        public ClaimId ClaimId { get; private set; }

        public RoleClaim() : base(default) { }

        public RoleClaim(RoleClaimId id, RoleId roleId, ClaimId claimId) : base(id)
        {
            RoleId = roleId;
            ClaimId = claimId;
        }
    }
}
