namespace TN.Client.Services.Shared.Interfaces
{
    public interface IVibrationService
    {
        Task<bool> Vibrate(int seconnds);
    }
}
