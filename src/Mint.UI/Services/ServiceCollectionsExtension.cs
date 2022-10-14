using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;

namespace Mint.UI.Services;

public static class ServiceCollectionsExtension
{
    public static void SetSession<T>(this ISession session, string key, T value)
    {
        if (session.GetString(key) == null)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }
        else
        {
            session.Remove(key);
            session.SetString(key, JsonSerializer.Serialize(value));
        }
    }

    public static string GetSession(this ISession session, string key)
    {
        var value = session.GetString(key);
        return value!;
    }

    public static string GetRole(this ISession session, string key)
    {
        try
        {
            var value = session.GetString(key);
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(value);
            return token.Claims.First(c => c.Type == ClaimTypes.Role).Value ?? null!;
        }
        catch
        {
            return null!;
        }
    }

    public static void RemoveSession(this ISession session, string key)
    {
        if (session.GetString(key) != null)
        {
            session.Remove(key);
        }
    }
}
