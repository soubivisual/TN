namespace TN.Shared.Utils.Misc.Time
{
    public sealed class UtcClock : IClock
    {
        public DateTime CurrentDate() => DateTime.UtcNow;

        public long CurrentTimestamp() => DateTime.UtcNow.ToUnixTime();
    }
}
