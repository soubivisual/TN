using TN.Client.Services.Shared.Interfaces;

namespace TN.Client.Services.Shared.Implementations.Web
{
    public sealed class VibrationService : IVibrationService
    {
        public Task<bool> Vibrate(int seconds)
        {
            return Task.FromResult(false);
        }
    }
}
