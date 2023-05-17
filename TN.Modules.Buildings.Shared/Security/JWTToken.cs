using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace TN.Modules.Buildings.Shared.Security
{
    public static class JWTToken
    {
        public const string SecretKey = "dsV1b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b9545F5b7a0812e1081c39b740293f765eae731f5a65ed";

        public static string GenerateJwtToken(IEnumerable<Claim> claims, string issuer = null, string audience = null, int? expiration = null)
        {
            var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
            var credentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256Signature);
            var expires = expiration.HasValue ? DateTime.UtcNow.AddMinutes(expiration.Value) : DateTime.UtcNow.AddMinutes(30);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: expires,
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static (bool IsSucess, Exception Exception, ClaimsPrincipal ClaimsPrincipal, SecurityToken SecurityToken) ValidateJwtToken(string jwtToken, string issuer, string audience)
        {
            var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = audience,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = symmetricKey,
                    ClockSkew = TimeSpan.Zero,
                };

                var claimsPrincipal = tokenHandler.ValidateToken(jwtToken, validationParameters, out SecurityToken securityToken);

                return (true, null, claimsPrincipal, securityToken);
            }
            catch (Exception ex)
            {
                return (false, ex, null, null);
            }
        }

        public static string GetClaimValue(this ClaimsPrincipal claimsPrincipal, string type)
        {
            return claimsPrincipal.Claims.FirstOrDefault(q => q.Type == type)?.Value;
        }
    }
}
