using TN.Modules.Buildings.Shared.SharedKernel;

namespace TN.Modules.Configurations.Domain.Catalogs.ValueObjects
{
    public sealed class CatalogDescriptionId : ValueObjectBase<int>
    {
        public CatalogDescriptionId(int value) : base(value) { }

        public static implicit operator CatalogDescriptionId(int value) => new(value);

        public static implicit operator int(CatalogDescriptionId value) => value.Value;
    }
}
