using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Mint.Domain.Extensions;

public class Constants
{
    public const string ISSUER = "https://localhost:7190/";
    public const string AUDIENCE = "https://localhost:7190/";
    private const string key = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG412V8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==";

    public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
        new(Encoding.UTF8.GetBytes(key));

    public const string ADMIN = "Admin";
    public const string BUYER = "Buyer";

    public const string TOKEN_SCHEME = "Bearer";

    public const string CONNECTION_STRING = "Default";
}