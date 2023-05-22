using System;
using Microsoft.JSInterop;
namespace TN.Client.Services.Shared.Interfaces
{
	public interface IGeolocationService
	{
        Task<bool> ValidatePermission(IJSRuntime jSRuntime = null);
        Task<Tuple<double, double>> RequestGeolocation(IJSRuntime jSRuntime = null);
    }
}

