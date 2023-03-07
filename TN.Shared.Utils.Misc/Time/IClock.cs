namespace TN.Shared.Utils.Misc.Time
{
    public interface IClock
    {
        DateTime CurrentDate();

        long CurrentTimestamp();
    }
}
