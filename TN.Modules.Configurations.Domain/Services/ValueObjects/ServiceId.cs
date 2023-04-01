using TN.Modules.Buildings.Shared.SharedKernel;

namespace TN.Modules.Configurations.Domain.Services.ValueObjects
{
    public sealed class ServiceId : ValueObjectBase<int>
    {
        public ServiceId(int value) : base(value) { }

        public static implicit operator ServiceId(int value) => new(value);

        public static implicit operator int(ServiceId value) => value.Value;
    }
}
