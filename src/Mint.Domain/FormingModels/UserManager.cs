using Mint.Domain.Models;
using Mint.Domain.ViewModels;

namespace Mint.Domain.FormingModels;

public class UserManager
{
    public UserViewModel FormingViewModel(User user)
    {
		try
		{
			return new UserViewModel()
			{
				Id = user.Id,
				FirstName = user.FirstName,
				SecondName = user.SecondName,
				LastName = user.LastName,
				Email = user.Email,
				Phone = user.Phone,
				CreatedDate = user.CreatedDate,
			};
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message, ex);
		}
    }
}
