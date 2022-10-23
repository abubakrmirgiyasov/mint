using Mint.Domain.BindingModels;
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

	public User FormingBindingModel(UserBindingModel user)
	{
		try
		{
			var newUser = new User()
			{
				Id = Guid.NewGuid(),
                FirstName = user.FirstName!,
                SecondName = user.SecondName!,
                LastName = user.LastName,
                Email = user.Email!,
                Phone = (long)user.Phone!,
				Ip = user.Ip!,
                Password = user.Password,
                ConfirmedPassword = user.ConfirmPassword,
				Photos = new List<Photo>(),
			};

            newUser.Photos!.Add(new Photo()
            {
                FileName = user.Photo!.FileName,
                FileExtension = user.Photo.FileExtension,
                FilePath = user.Photo.FilePath,
                FileSize = user.Photo.FileSize,
                FileBytes = user.Photo.FileBytes,
                UserId = newUser.Id,
            });

            return newUser;
        }
        catch (Exception ex)
		{
			throw new Exception(ex.Message, ex);
		}
	}
}
