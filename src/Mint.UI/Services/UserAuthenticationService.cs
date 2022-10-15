using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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
                    new Claim(ClaimTypes.Role, jwt.Claims.First(claim => claim.Type == ClaimTypes.Role).Value),
                    new Claim(ClaimTypes.NameIdentifier, jwt.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value),
                    new Claim(ClaimTypes.UserData, jwt.Claims.First(claim => claim.Type == ClaimTypes.UserData)!.Value),
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

    public static Guid GetUserId(this HttpContext context)
    {
        try
        {
            var token = ServiceCollectionsExtension.GetSession(context.Session, "__ID-acces-token");
            if (token != null)
            {
                var handler = new JwtSecurityTokenHandler();
                var jwt = handler.ReadJwtToken(token);
                var claim = new Claim(ClaimTypes.NameIdentifier, jwt.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value);
                return Guid.Parse(claim.Value);
            }
            return Guid.Empty;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public static string GetUserPicture(this HttpContext context)
    {
        try
        {
            var token = ServiceCollectionsExtension.GetSession(context.Session, "__ID-acces-token");
            if (token != null)
            {
                var handler = new JwtSecurityTokenHandler();
                var jwt = handler.ReadJwtToken(token);
                var claim = new Claim(ClaimTypes.UserData, jwt.Claims.First(claim => claim.Type == ClaimTypes.UserData).Value);
                if (claim.Value != "")
                {
                    return claim.Value;
                }
            }
            return null!;
        }
        catch
        {
            return null!;
        }
    }
}
