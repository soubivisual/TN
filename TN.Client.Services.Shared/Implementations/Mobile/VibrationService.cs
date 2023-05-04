using TN.Client.Services.Shared.Interfaces;

namespace TN.Client.Services.Shared.Implementations.Mobile
{
    public sealed class VibrationService : IVibrationService
    {
        public Task<bool> Vibrate(int seconds)
        {
            TimeSpan vibrationTime = TimeSpan.FromSeconds(seconds);

            Vibration.Default.Vibrate(vibrationTime);

            return Task.FromResult(true);
        }
    }
}
