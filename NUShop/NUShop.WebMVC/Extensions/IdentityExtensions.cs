using System.Linq;
using System.Security.Claims;

namespace NUShop.WebMVC.Extensions
{
    public static class IdentityExtensions
    {
        public static string GetSpecificClaim(this ClaimsPrincipal claimsPrincipal, string claimsKey)
        {
            if (!string.IsNullOrEmpty(claimsKey))
            {
                var claim = claimsPrincipal.Claims.FirstOrDefault(x => x.Type == claimsKey);
                return claim == null ? string.Empty : claim.Value;
            }
            return string.Empty;
        }
    }
}