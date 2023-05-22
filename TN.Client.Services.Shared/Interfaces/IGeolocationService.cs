using System;
namespace TN.Client.Services.Shared.Interfaces
{
	public interface IGeolocationService
	{
        Task<bool> ValidatePermission();
        Task<Tuple<double, double>> RequestGeolocation();
    }
}

