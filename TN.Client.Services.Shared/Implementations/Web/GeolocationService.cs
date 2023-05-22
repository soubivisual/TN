using System;
using Microsoft.JSInterop;
using Microsoft.Maui.Devices.Sensors;
using TN.Client.Services.Shared.Interfaces;

namespace TN.Client.Services.Shared.Implementations.Web
{
    public class GeolocationService : IGeolocationService
    {
        public async Task<Tuple<double, double>> RequestGeolocation(IJSRuntime jSRuntime = null)
        {
            try
            {
                double[] result = await jSRuntime.RequestGeolocationPermission();
                return result == null ? null : Tuple.Create(result[0], result[1]);
            }
            catch (Exception ex)
            {
                return null;
            }
           
        }

        public async Task<bool> ValidatePermission(IJSRuntime jSRuntime = null)
        {
            try
            {
                var result = await jSRuntime.ValidateGeolocationPermission();
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}

