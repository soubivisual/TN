using TN.Modules.Buildings.Shared.SharedKernel;
using TN.Modules.Identities.Domain.Roles.ValueObjects;

namespace TN.Modules.Identities.Domain.Roles.Aggregates
{
    public sealed class Role : AggregateRootBase<RoleId>
    {
        public string Name { get; private set; }

        public Role() : base(default) { }

        public Role(RoleId id, string name) : base(id)
        {
            Name = name;
        }
    }
}
