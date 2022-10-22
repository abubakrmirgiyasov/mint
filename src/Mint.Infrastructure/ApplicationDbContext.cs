using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Mint.Domain.Extensions;
using Mint.Domain.Models;

namespace Mint.Infrastructure;

public class ApplicationDbContext : DbContext
{
	public DbSet<User> Users { get; set; } = null!;

	public DbSet<Photo> Photos { get; set; } = null!;

	public DbSet<Role> Roles { get; set; } = null!;

	public DbSet<Category> Categories { get; set; } = null!;

	public DbSet<Brand> Brands { get; set; } = null!;

	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
		: base(options) { }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		builder.Entity<User>()
			.HasOne(x => x.Role)
			.WithMany(x => x.Users)
			.HasForeignKey(x => x.RoleId)
			.OnDelete(DeleteBehavior.Cascade);

		builder.Entity<Photo>()
			.HasOne(x => x.User)
			.WithMany(x => x.Photos)
			.HasForeignKey(x => x.UserId)
			.OnDelete(DeleteBehavior.NoAction);

		builder.Entity<User>()
			.HasIndex(x => x.Email)
			.IsUnique(true);

		builder.Entity<User>()
			.HasIndex(x => x.Phone)
			.IsUnique(true);

        builder.Entity<Photo>()
            .HasOne(x => x.Brand)
            .WithMany(x => x.Photos)
            .HasForeignKey(x => x.BrandId)
            .OnDelete(DeleteBehavior.NoAction);

		builder.Entity<Brand>()
			.HasOne(x => x.Category)
			.WithMany(x => x.Brands)
			.HasForeignKey(x => x.CategoryId)
			.OnDelete(DeleteBehavior.NoAction);

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
			},
			new Role()
			{
				Id = Guid.NewGuid(),
				Name = "Deliver",
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
				Ip = "127.0.0.1",
				Password = Encrypt.EncodePassword("AbuakrMirgiyasov@))!M"),
				ConfirmedPassword = Encrypt.EncodePassword("AbuakrMirgiyasov@))!M"),
				RoleId = roles[0].Id,
			},
			new User()
            {
                FirstName = "Test",
                SecondName = "User",
                Email = "test@gmail.com",
                Phone = 89502768529,
                Ip = "127.0.0.2",
                Password = Encrypt.EncodePassword("test_1"),
                ConfirmedPassword = Encrypt.EncodePassword("test_1"),
                RoleId = roles[1].Id,
            }
        };

		var categories = new Category[]
		{
			new Category() 
			{
				Id = Guid.NewGuid(),
				Name = "Смартфоны",
			},
            new Category() 
			{
				Id = Guid.NewGuid(),
				Name = "Аксессуары",
			},
            new Category() 
			{ 
				Id = Guid.NewGuid(),
				Name = "Гаджеты",
			},
        };

		var brands = new Brand[]
		{
			new Brand()
			{
				Name = "Apple Iphone",
				CategoryId = categories[0].Id,
			},
			new Brand()
			{
                Name = "Xiaomi",
                CategoryId = categories[0].Id,
            },
            new Brand()
            {
                Name = "Экшн-камеры",
                CategoryId = categories[2].Id,
            },
            new Brand()
            {
                Name = "Умные брелоки",
                CategoryId = categories[2].Id,
            },
			new Brand()
			{
				Name = "Смарт часы",
				CategoryId = categories[1].Id,
			}
		};

		builder.Entity<Role>().HasData(roles);
		builder.Entity<User>().HasData(users);
		builder.Entity<Brand>().HasData(brands);
		builder.Entity<Category>().HasData(categories);
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
