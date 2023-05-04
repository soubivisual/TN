using System;
using System.Threading.Tasks;
using Microsoft.Maui.Devices;
using TN.Client.Services.Interfaces;

namespace TN.Client.Services.MAUIBlazor
{
    public class VibrationService : IVibrationService
    {
        public Task<bool> Vibrate(int seconds)
        {
            TimeSpan vibrationTime = TimeSpan.FromSeconds(seconds);
            Vibration.Default.Vibrate(vibrationTime);
            return Task.FromResult(true);
        }
    }
}

