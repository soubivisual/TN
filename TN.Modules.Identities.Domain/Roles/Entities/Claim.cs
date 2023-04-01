using TN.Modules.Buildings.Shared.SharedKernel;

namespace TN.Modules.Identities.Domain.Roles.Entities
{
    public sealed class Claim : EntityBase<int>
    {
        public string Type { get; private set; }

        public string Value { get; private set; }

        public Claim(int id) : base(id) { }

        public Claim(int id, string type, string value) : base(id)
        {
            Type = type;
            Value = value;
        }
    }
}
