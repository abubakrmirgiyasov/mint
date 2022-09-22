using System.Text;

namespace Mint.Domain.Extensions;

public static class Encrypt
{
    public static string EncodePassword(string password)
    {
		try
		{
			var encoding = new byte[password.Length];
			encoding = Encoding.UTF8.GetBytes(password);

			var encoded = Convert.ToBase64String(encoding);
			return encoded;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message, ex);
		}
    }
}
