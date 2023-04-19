using TN.Modules.Buildings.Shared.SharedKernel;
using TN.Modules.Identities.Domain.Roles.ValueObjects;
using TN.Modules.Identities.Domain.Users.ValueObjects;

namespace TN.Modules.Identities.Domain.Users.Entities
{
    public sealed class UserRole : EntityBase<UserRoleId>
    {
        public UserId UserId { get; private set; }

        public RoleId RoleId { get; private set; }

        public UserRole() : base(default) { }

        public UserRole(UserRoleId id, UserId userId, RoleId roleId) : base(id)
        {
            UserId = userId;
            RoleId = roleId;
        }
    }
}
