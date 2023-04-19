using TN.Modules.Buildings.Shared.SharedKernel;

namespace TN.Modules.Configurations.Domain.Catalogs.ValueObjects
{
    public sealed class CatalogId : ValueObjectBase<Guid>
    {
        public CatalogId(Guid value) : base(value) { }

        public static implicit operator CatalogId(Guid value) => new(value);

        public static implicit operator Guid(CatalogId value) => value.Value;
    }
}
