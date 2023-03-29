using TN.Modules.Buildings.Shared.SharedKernel;
using TN.Modules.Remittances.Domain.Remittances.ValueObjects;

namespace TN.Modules.Remittances.Domain.Remittances.Aggregates
{
    public sealed class Remittance : AggregateRootBase<RemittanceId>
    {
        public int TenantId { get; private set; }

        public int UserId { get; private set; }

        public int ServiceId { get; private set; }

        public string SenderIdentification { get; private set; }

        public string ReceiverIdentification { get; private set; }

        public string SenderFullName { get; private set; }

        public string ReceiverFullName { get; private set; }

        public Guid SenderCurrencyId { get; private set; }

        public Guid ReceiverCurrencyId { get; private set; }

        public decimal SenderAmount { get; private set; }

        public decimal ReceiverAmount { get; private set; }

        public decimal ExchangeRate { get; private set; }

        public DateTime Date { get; private set; }

        public Guid StatusId { get; private set; }

        public Guid CoreProcessId { get; private set; }

        public string Message { get; private set; }

        public string Data { get; private set; }

        public Remittance() : base(default) { }

        public Remittance(RemittanceId id, int tenantId, int userId, int serviceId, string senderIdentification, string receiverIdentification, string senderFullName, string receiverFullName, Guid senderCurrencyId, Guid receiverCurrencyId, decimal senderAmount, decimal receiverAmount, decimal exchangeRate, DateTime date, Guid statusId, Guid coreProcessId, string message, string data) : base(id)
        {
            TenantId = tenantId;
            UserId = userId;
            ServiceId = serviceId;
            StatusId = statusId;
            SenderIdentification = senderIdentification;
            ReceiverIdentification = receiverIdentification;
            SenderFullName = senderFullName;
            ReceiverFullName = receiverFullName;
            SenderCurrencyId = senderCurrencyId;
            ReceiverCurrencyId = receiverCurrencyId;
            SenderAmount = senderAmount;
            ReceiverAmount = receiverAmount;
            ExchangeRate = exchangeRate;
            Date = date;
            StatusId = statusId;
            CoreProcessId = coreProcessId;
            Message = message;
            Data = data;
        }
    }
}
