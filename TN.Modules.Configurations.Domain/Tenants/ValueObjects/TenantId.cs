using TN.Modules.Buildings.Shared.SharedKernel;

namespace TN.Modules.Configurations.Domain.Tenants.ValueObjects
{
    public sealed class TenantId : ValueObjectBase<int>
    {
        public TenantId(int value) : base(value) { }

        public static implicit operator TenantId(int value) => new(value);

        public static implicit operator int(TenantId value) => value.Value;
    }
}
