using System;
using Microsoft.Maui.ApplicationModel.Communication;
using TN.Client.Services.Shared.Interfaces;

namespace TN.Client.Services.Shared.Implementations.Mobile
{
    public class GeolocationService : IGeolocationService
    {
        public async Task<Tuple<double, double>> RequestGeolocation()
        {
            CancellationTokenSource _cancelTokenSource;

            GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

            _cancelTokenSource = new CancellationTokenSource();

            Location location = await Microsoft.Maui.Devices.Sensors.Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);

            return Tuple.Create(location.Latitude, location.Longitude);
        }

        public async Task<bool> ValidatePermission()
        {
            PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            if (status != PermissionStatus.Granted)
            {
                await Permissions.RequestAsync<Permissions.LocationWhenInUse>()
                    .ContinueWith(async (_) =>
                    {
                        status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
                    });
                return status == PermissionStatus.Granted;
            }
            else
            {
                return true;
            }
        }
    }
}

