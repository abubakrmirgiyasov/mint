using Mint.Domain.BindingModels;
using Mint.Domain.ViewModels;

namespace Mint.Domain.FormingBindingModel;

public class UsersManager
{
    public UserBindingModel FormingBindingModel(UserViewModel user)
    {
		try
		{


			return new UserBindingModel();
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message, ex);
		}
    }
}
