using TN.Modules.Buildings.Shared.SharedKernel;

namespace TN.Modules.Remittances.Domain.Remittances.ValueObjects
{
    public sealed class RemittanceId : ValueObjectBase<long>
    {
        public RemittanceId(long value) : base(value)
        {

        }

        public static implicit operator RemittanceId(long value) => new(value);

        public static implicit operator long(RemittanceId value) => value.Value;
    }
}
