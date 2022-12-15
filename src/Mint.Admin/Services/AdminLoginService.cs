using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mint.Admin.Services;

public class AdminLoginService
{
	private readonly PageModel _page;

	public AdminLoginService(PageModel page)
	{
		_page = page;
	}

	public bool IsAuthenticated()
	{
		var identity = _page.HttpContext.GetClaimIdentity();
		return identity.IsAuthenticated;
	}
}
