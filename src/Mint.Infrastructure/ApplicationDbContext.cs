using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Mint.Domain.Extensions;
using Mint.Domain.Models;

namespace Mint.Infrastructure;

public class ApplicationDbContext : DbContext
{
	public DbSet<User> Users { get; set; } = null!;

	//public DbSet<Photo> Photos { get; set; } = null!;

	public DbSet<Role> Roles { get; set; } = null!;

	//public DbSet<Error> Errors { get; set; } = null!;

	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
		: base(options) { }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		builder.Entity<User>()
			.HasOne(x => x.Role)
			.WithMany(x => x.Users)
			.HasForeignKey(x => x.RoleId)
			.OnDelete(DeleteBehavior.Cascade);

		//builder.Entity<Photo>()
		//	.HasOne(x => x.User)
		//	.WithMany(x => x.Photos)
		//	.HasForeignKey(x => x.UserId)
		//	.OnDelete(DeleteBehavior.NoAction);

		var roles = new Role[]
		{
			new Role()
			{
				Id = Guid.NewGuid(),
				Name = "Admin",
			},
			new Role()
			{
				Id = Guid.NewGuid(),
				Name = "Buyer",
			}
		};

		var users = new User[]
		{
			new User()
			{
				FirstName = "Миргиясов",
				SecondName = "Абубакр",
				LastName = "Мукимжонович",
				Email = "abubakrmirgiyasov@gmail.com",
				Phone = 89502768428,
				Password = Encrypt.EncodePassword("AbuakrMirgiyasov@))!M"),
				ConfirmedPassword = Encrypt.EncodePassword("AbuakrMirgiyasov@))!M"),
				RoleId = roles[0].Id,
			},
			new User()
            {
                FirstName = "Test",
                SecondName = "User",
                LastName = "",
                Email = "test@gmail.com",
                Phone = 89502768428,
                Password = Encrypt.EncodePassword("test_1"),
                ConfirmedPassword = Encrypt.EncodePassword("test_1"),
                RoleId = roles[1].Id,
            }
        };

		builder.Entity<Role>().HasData(roles);
		builder.Entity<User>().HasData(users);
	}

	public async Task<List<Photo>> AddPhotoAsync(IFormFileCollection files)
	{
		try
		{
            var photos = new List<Photo>();

			if (files.Count > 0)
			{
				foreach (var file in files)
				{
					if (file.Length > 0)
					{
						using var ms = new MemoryStream();

						await file.CopyToAsync(ms);

						if (ms.Length < 4194304)
						{
							var newPhoto = new Photo()
							{
								FileName = Path.GetFileName(file.FileName),
								FileSize = ms.Length,
								FileExtension = Path.GetExtension(file.FileName.Contains(".webp") ? file.FileName : ".webp"),
								FilePath = Path.GetFullPath(file.FileName),
								FileBytes = ms.ToArray(),
							};

							photos.Add(newPhoto);
						}
					}
				}
			}

            return photos;
        }
        catch (Exception ex)
		{
			throw new Exception(ex.Message, ex);
		}
	}
}
