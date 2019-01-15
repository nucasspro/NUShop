using System;
using System.Linq;
using System.Security.Claims;

namespace NUShop.WebMVC.Extensions
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

        public static Guid GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            var claim = ((ClaimsIdentity)claimsPrincipal.Identity).Claims.Single(x => x.Type == "UserId");
            return Guid.Parse(claim.Value);
        }
    }
}