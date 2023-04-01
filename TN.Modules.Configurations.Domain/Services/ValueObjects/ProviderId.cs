using TN.Modules.Buildings.Shared.SharedKernel;

namespace TN.Modules.Configurations.Domain.Services.ValueObjects
{
    public sealed class ProviderId : ValueObjectBase<int>
    {
        public ProviderId(int value) : base(value) { }

        public static implicit operator ProviderId(int value) => new(value);

        public static implicit operator int(ProviderId value) => value.Value;
    }
}
