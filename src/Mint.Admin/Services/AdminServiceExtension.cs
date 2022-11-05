using Mint.Middleware.Extensions;
using Mint.Middleware.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;

namespace Mint.Admin.Services;

public static class AdminServiceExtension
{
	public static bool IsAuthenticated(this HttpContext context)
	{
		try
		{
			var identity = GetClaimIdentity(context);
			return identity.IsAuthenticated;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message, ex);
		}
	}

	public static ClaimsIdentity GetClaimIdentity(this HttpContext context)
	{
		try
		{
			var claims = GetClaims(context);
			if (claims.Count != 0)
			{
				var identity = new ClaimsIdentity(claims, Params.AuthenticationType);
				return identity;
			}
			return new ClaimsIdentity();
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
			var token = SessionCollectionsExtension.GetSession(context.Session, Params.SESSION_TOKEN_NAME);
            if (token != null)
			{
				var handler = new JwtSecurityTokenHandler();
				var jwt = handler.ReadJwtToken(JsonSerializer.Deserialize<string>(token));
				return new List<Claim>
				{
					new Claim(ClaimTypes.Name, jwt.Claims.First(claim => claim.Type == ClaimTypes.Name).Value),
					new Claim(ClaimTypes.GivenName, jwt.Claims.First(claim => claim.Type == ClaimTypes.GivenName).Value),
					new Claim(ClaimTypes.Email, jwt.Claims.First(claim => claim.Type == ClaimTypes.Email).Value),
					new Claim(ClaimTypes.Role, jwt.Claims.First(claim => claim.Type == ClaimTypes.Role).Value),
                };
			}
			return new List<Claim>();
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message, ex);
		}
	}

	public static string GetFullName(this HttpContext context)
	{
		try
		{
			var token = SessionCollectionsExtension.GetSession(context.Session, Params.SESSION_TOKEN_NAME);
			if (token != null)
			{
				var handler = new JwtSecurityTokenHandler();
				var jwt = handler.ReadJwtToken(JsonSerializer.Deserialize<string>(token));
				var claims = new List<Claim>()
				{
					new Claim(ClaimTypes.Name, jwt.Claims.First(claim => claim.Type == ClaimTypes.Name).Value),
					new Claim(ClaimTypes.GivenName, jwt.Claims.First(claim => claim.Type == ClaimTypes.GivenName).Value),
				};
				return $"{claims[0].Value} {claims[1].Value}";
			}
			return null!;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message, ex);
		}
	}
}
