using System;
namespace TN.Client.Services.Interfaces
{
	public interface IVibrationService
	{
        Task<bool> Vibrate(int seconnds);
	}
}

