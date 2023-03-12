using TN.Modules.Buildings.Shared.Exceptions;

namespace TN.Modules.Configurations.Domain.Catalogs.Exceptions
{
    internal sealed class InvalidCatalogTypeException : BaseException
    {
        public string Type { get; }

        public InvalidCatalogTypeException(string type) : base(400, $"Type: '{type}' is invalid.")
        { 
            Type = type;
        }
    }
}
