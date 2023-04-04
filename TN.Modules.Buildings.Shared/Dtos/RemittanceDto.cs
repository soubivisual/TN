namespace TN.Modules.Buildings.Shared.Dtos
{
    public sealed class RemittanceDto : BaseDto
    {
        public long Id { get; set; }

        public int TenantId { get; set; }

        public int UserId { get; set; }

        public int ServiceId { get; set; }

        public string SenderIdentification { get; set; }

        public string ReceiverIdentification { get; set; }

        public string SenderFullName { get; set; }

        public string ReceiverFullName { get; set; }

        public Guid SenderCurrencyId { get; set; }

        public Guid ReceiverCurrencyId { get; set; }

        public decimal SenderAmount { get; set; }

        public decimal ReceiverAmount { get; set; }

        public decimal ExchangeRate { get; set; }

        public DateTime Date { get; set; }

        public Guid StatusId { get; set; }

        public Guid CoreProcessId { get; set; }

        public string Message { get; set; }

        public string Data { get; set; }
    }
}
