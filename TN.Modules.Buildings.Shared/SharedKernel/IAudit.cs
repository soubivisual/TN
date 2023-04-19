namespace TN.Modules.Buildings.Shared.SharedKernel
{
    public interface IAudit
    {
        public int? AddedUserId { get; }

        public DateTime? AddedDate { get; }

        public int? EditedUserId { get; }

        public DateTime? EditedDate { get; }
    }
}
