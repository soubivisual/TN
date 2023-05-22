using System;
using TN.Client.Services.Shared.Interfaces;

namespace TN.Client.Services.Shared.Implementations.Web
{
    public class GeolocationService : IGeolocationService
    {
        public Task<Tuple<double, double>> RequestGeolocation()
        {
            throw new NotImplementedException();
        }

        public Task<bool> ValidatePermission()
        {
            throw new NotImplementedException();
        }
    }
}

