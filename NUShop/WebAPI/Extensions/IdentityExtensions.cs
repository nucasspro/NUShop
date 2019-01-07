using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NUShop.WebAPI.Extensions
{
    public static class IdentityExtensions
    {
        public static string GetSpecificClaim(this ClaimsPrincipal claimsPrincipal, string claimsKey)
        {
            if (string.IsNullOrEmpty(claimsKey))
            {
                return string.Empty;
            }

            var claim = claimsPrincipal.Claims.FirstOrDefault(x => x.Type == claimsKey);
            return claim == null ? string.Empty : claim.Value;
        }
    }
}
