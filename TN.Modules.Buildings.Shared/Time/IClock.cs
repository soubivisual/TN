namespace TN.Modules.Buildings.Shared.Time
{
    public interface IClock
    {
        DateTime CurrentDate();

        long CurrentTimestamp();
    }
}
