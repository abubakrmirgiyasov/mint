namespace Mint.Middleware.Extensions;

public class Params
{
    public static string AccessToken { get; set; } = null!;

    public static int ExpireTokenTime { get; set; } = 1;

    public const string SESSION_TOKEN_NAME = "__ID-acces-token";

    public static string AuthenticationType => "oauth2";
}
