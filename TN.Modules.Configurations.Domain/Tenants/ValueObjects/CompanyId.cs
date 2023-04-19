using TN.Modules.Buildings.Shared.SharedKernel;

namespace TN.Modules.Configurations.Domain.Tenants.ValueObjects
{
    public sealed class CompanyId : ValueObjectBase<int>
    {
        public CompanyId(int value) : base(value) { }

        public static implicit operator CompanyId(int value) => new(value);

        public static implicit operator int(CompanyId value) => value.Value;
    }
}
