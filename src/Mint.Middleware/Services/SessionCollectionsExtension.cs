using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Mint.Middleware.Services;

public static class SessionCollectionsExtension
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

    public static void RemoveSession(this ISession session, string key)
    {
        if (session.GetString(key) != null)
        {
            session.Remove(key);
        }
    }
}
