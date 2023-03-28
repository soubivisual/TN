namespace TN.Modules.Buildings.Shared.Dtos
{
    public sealed class NotificationDto
    {
        public long Id { get; set; }

        public int TenantId { get; private set; }

        public int UserId { get; private set; }

        public Guid TypeId { get; private set; }

        public Guid StatusId { get; private set; }

        public short Priority { get; private set; }

        public string Title { get; private set; }

        public string Text { get; private set; }

        public string CallbackUrl { get; private set; }

        public bool Read { get; private set; }

        public DateTime Date { get; private set; }

        public DateTime ReadDate { get; private set; }

        public DateTime ExpirationDate { get; set; }

        public Guid CoreProcessId { get; set; }
    }
}
