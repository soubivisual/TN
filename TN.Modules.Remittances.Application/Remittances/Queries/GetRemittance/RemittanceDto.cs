namespace TN.Modules.Remittances.Application.Remittances.Queries.GetRemittance
{
    public sealed class RemittanceDto
    {
        public long Id { get; set; }

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

        public Guid CoreProcessId { get; set; }

        public string Message { get; set; }

        public string Data { get; set; }
    }
}
