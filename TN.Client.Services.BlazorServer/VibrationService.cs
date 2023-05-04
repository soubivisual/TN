using System;
using System.Threading.Tasks;
using TN.Client.Services.Interfaces;

namespace TN.Client.Services.BlazorServer
{
    public class VibrationService : IVibrationService
    {
        public Task<bool> Vibrate(int seconds) => Task.FromResult(false);
    }
}

