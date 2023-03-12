using TN.Modules.Buildings.Domain.ValueObjects;
using TN.Modules.Configurations.Domain.Catalogs.Enums;
using TN.Modules.Configurations.Domain.Catalogs.Exceptions;

namespace TN.Modules.Configurations.Domain.Catalogs.ValueObjects
{
    public sealed class CatalogType : ValueObjectBase<string>
    {
        public CatalogType(string value) : base(value)
        {
            if (!Enum.IsDefined(typeof(CatalogTypes), value))
            {
                throw new InvalidCatalogTypeException(value);
            }
        }

        public static implicit operator CatalogType(string value) => new(value);

        public static implicit operator string(CatalogType value) => value.Value;
    }
}
