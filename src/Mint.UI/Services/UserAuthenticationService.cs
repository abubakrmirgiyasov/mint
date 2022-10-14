using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Mint.UI.Services;

public static class UserAuthenticationService
{
    public static bool IsAuthenticated(this HttpContext context)
    {
        try
        {
            var identity = GetClaimsIdentity(context);
            return identity.IsAuthenticated;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public static List<Claim> GetClaims(this HttpContext context)
    {
        try
        {
            var token = ServiceCollectionsExtension.GetSession(context.Session, "__ID-acces-token");
            if (token != null)
            {
                var handler = new JwtSecurityTokenHandler();
                var jwt = handler.ReadJwtToken(token);
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, jwt.Claims.First(claim => claim.Type == ClaimTypes.Name).Value),
                    new Claim(ClaimTypes.Email, jwt.Claims.First(claim => claim.Type == ClaimTypes.Email).Value),
                    new Claim(ClaimTypes.Role, jwt.Claims.First(claim => claim.Type == ClaimTypes.Role).Value)
                };
                return claims;
            }

            return new List<Claim>();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public static ClaimsIdentity GetClaimsIdentity(this HttpContext context)
    {
        try
        {
            var claims = GetClaims(context);

            if (claims.Count != 0)
            {
                var identity = new ClaimsIdentity(claims, "oauth2");
                return identity;
            }

            return new ClaimsIdentity();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public static ClaimsPrincipal GetPrincipal(this HttpContext context)
    {
        try
        {
            var principal = new ClaimsPrincipal(GetClaimsIdentity(context));
            return principal;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}
