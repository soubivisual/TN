using TN.Shared.Utils.Misc;

namespace TN.Modules.Buildings.Shared.Time
{
    public sealed class UtcClock : IClock
    {
        public DateTime CurrentDate() => DateTime.UtcNow;

        public long CurrentTimestamp() => DateTime.UtcNow.ToUnixTime();
    }
}
