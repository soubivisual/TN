using Microsoft.AspNetCore.Components;
using System;
using System.Web;

namespace TN.Client.Components.Shared.Helpers
{
	public static class NavigationManagerHelpers
	{
        public static string AddQueryParm(this NavigationManager navigationManager, string parmName, string parmValue)
        {
            var uriBuilder = new UriBuilder(navigationManager.Uri);
            var q = HttpUtility.ParseQueryString(uriBuilder.Query);
            q[parmName] = parmValue;
            uriBuilder.Query = q.ToString();
            var newUrl = uriBuilder.ToString();
            return newUrl;
        }

        public static string GetQueryParm(this NavigationManager navigationManager, string parmName)
        {
            var uriBuilder = new UriBuilder(navigationManager.Uri);
            var q = HttpUtility.ParseQueryString(uriBuilder.Query);
            return q[parmName] ?? string.Empty;
        }

        public static bool IsSelected(this NavigationManager navigationManager, string uri)
        {
            if (navigationManager.Uri.EndsWith(uri) || navigationManager.Uri.Contains(uri + "/"))
                return true;

            return false;
        }

        public static string GetHost(this NavigationManager navigationManager)
        {
            return new Uri(navigationManager.BaseUri).Host;
        }
    }
}

