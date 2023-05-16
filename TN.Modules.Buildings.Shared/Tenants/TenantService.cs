using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TN.Modules.Buildings.Shared.Security;
using TN.Shared.Utils.Misc;

namespace TN.Modules.Buildings.Shared.Tenants
{
    internal class TenantService : ITenantService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TenantService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int GetTenantId()
        {
            var httpContext = _httpContextAccessor.HttpContext;

            if (httpContext is null)
            {
                return default;
            }

            httpContext.Request.Headers.TryGetValue("Authorization", out var token);

            var cleanToken = token.ToString().Replace("Bearer ", "", StringComparison.InvariantCultureIgnoreCase);
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, "1"),
                new Claim(ClaimTypes.GroupSid, "1"),
            };
            var tokentemp = JWTToken.GenerateJwtToken(claims, "https://localhost", "https://localhost", 60000);
            var tokenValidation = JWTToken.ValidateJwtToken(cleanToken, "https://localhost", "https://localhost");

            if (!tokenValidation.IsSucess)
            {
                throw new Exception($"Token no válido. Detalle: {tokenValidation.Exception}");
            }

            var tenantId = tokenValidation.ClaimsPrincipal.GetClaimValue(ClaimTypes.GroupSid).ToInt();

            return tenantId;
        }
    }
}
