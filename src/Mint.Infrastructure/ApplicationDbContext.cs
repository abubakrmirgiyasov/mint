﻿using Microsoft.EntityFrameworkCore;
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

	public DbSet<Address> Addresses { get; set; } = null!;

	public DbSet<Country> Countries { get; set; } = null!;

	public DbSet<Admin> Admins { get; set; } = null!;

	public DbSet<SubCategory> SubCategories { get; set; } = null!;

	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		: base(options) { }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		builder.Entity<User>()
			.HasIndex(x => x.Email)
			.IsUnique(true);

		builder.Entity<User>()
			.HasIndex(x => x.Phone)
			.IsUnique(true);

		builder.Entity<Admin>()
			.HasIndex(x => x.Email)
			.IsUnique(true);

		builder.Entity<Admin>()
			.HasIndex(x => x.Phone)
			.IsUnique(true);

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

		builder.Entity<Photo>()
			.HasOne(x => x.Brand)
			.WithMany(x => x.Photos)
			.HasForeignKey(x => x.BrandId)
			.OnDelete(DeleteBehavior.NoAction);

		builder.Entity<Photo>()
			.HasOne(x => x.Category)
			.WithMany(x => x.Photos)
			.HasForeignKey(x => x.CategoryId)
			.OnDelete(DeleteBehavior.Cascade);

		builder.Entity<Photo>()
			.HasOne(x => x.SubCategory)
			.WithMany(x => x.Photos)
			.HasForeignKey(x => x.SubCategoryId)
			.OnDelete(DeleteBehavior.Cascade);

		builder.Entity<Category>()
			.HasOne(x => x.Brand)
			.WithMany(x => x.Categories)
			.HasForeignKey(x => x.BrandId)
			.OnDelete(DeleteBehavior.Cascade);

		builder.Entity<SubCategory>()
			.HasOne(x => x.Category)
			.WithMany(x => x.SubCategories)
			.HasForeignKey(x => x.CategoryId)
			.OnDelete(DeleteBehavior.NoAction);

		builder.Entity<Address>()
			.HasOne(x => x.Country)
			.WithMany(x => x.Addresses)
			.HasForeignKey(x => x.CountryId)
			.OnDelete(DeleteBehavior.Cascade);

		builder.Entity<User>()
			.HasOne(x => x.Address)
			.WithMany(x => x.Users)
			.HasForeignKey(x => x.AddressId)
			.OnDelete(DeleteBehavior.Cascade);

		builder.Entity<Admin>()
			.HasOne(x => x.Address)
			.WithMany(x => x.Admins)
			.HasForeignKey(x => x.AddressId)
			.OnDelete(DeleteBehavior.Cascade);

		builder.Entity<Photo>()
			.HasOne(x => x.Admin)
			.WithMany(x => x.Photos)
			.HasForeignKey(x => x.AdminId)
			.OnDelete(DeleteBehavior.NoAction);

		builder.Entity<Admin>()
			.HasOne(x => x.Role)
			.WithMany(x => x.Admins)
			.HasForeignKey(x => x.RoleId)
			.OnDelete(DeleteBehavior.Cascade);

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

		var countries = new Country[]
		{
			new Country()
			{
				Id = Guid.NewGuid(),
				Name = "Россия"
			}
		};

		var addresses = new Address[]
		{
			new Address()
			{
				Id = Guid.NewGuid(),
				City = "Новокузнецк",
				Street = "Бардина 23",
				Home = "302",
				Description = "г. Новокузнецк ул. Бардина 23, ком. 302",
				PostCode = 640000,
				CountryId = countries[0].Id,
			},
            new Address()
            {
                Id = Guid.NewGuid(),
                City = "Test",
                Street = "Street",
                Home = "302",
                Description = "г. Test Street, ком. 302",
                PostCode = 123456,
                CountryId = countries[0].Id,
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
				AddressId = addresses[0].Id,
			},
			new User()
			{
				FirstName = "Test",
				SecondName = "User",
				Email = "test@gmail.com",
				Phone = 89502768529,
				Ip = "127.0.0.1",
				Password = Encrypt.EncodePassword("test_1"),
				ConfirmedPassword = Encrypt.EncodePassword("test_1"),
				RoleId = roles[0].Id,
				AddressId = addresses[0].Id,
			}
		};

		var admins = new Admin[]
		{
			new Admin()
			{
				FirstName = "Миргиясов",
				SecondName = "Абубакр",
				LastName = "Мукимжонович",
				Email = "abubakrmirgiyasov@gmail.com",
				Phone = 89502768428,
				Password = Encrypt.EncodePassword("AbuakrMirgiyasov@))!M"),
				ConfirmedPassword = Encrypt.EncodePassword("AbuakrMirgiyasov@))!M"),
				AddressId = addresses[0].Id,
				RoleId = roles[0].Id,
			},
            new Admin()
            {
                FirstName = "Test",
                SecondName = "User",
                Email = "test@gmail.com",
                Phone = 89502768529,
                Password = Encrypt.EncodePassword("test_1"),
                ConfirmedPassword = Encrypt.EncodePassword("test_1"),
				RoleId = roles[0].Id,
                AddressId = addresses[1].Id,
			}
        };

        var brands = new Brand[]
        {
            new Brand()
            {
				Id = Guid.NewGuid(),
                Name = "Apple",
            },
            new Brand()
            {
                Id = Guid.NewGuid(),
                Name = "Xiaomi",
            },
            new Brand()
            {
                Id = Guid.NewGuid(),
                Name = "Samsung",
            },
        };

        var categories = new Category[]
		{
			new Category()
			{
				Id = Guid.NewGuid(),
				Name = "Смартфоны",
                BrandId = brands[0].Id,
            },
			new Category()
			{
				Id = Guid.NewGuid(),
                Name = "Аксессуары",
                BrandId = brands[1].Id,
            },
			new Category()
			{
				Id = Guid.NewGuid(),
                Name = "Гаджеты",
                BrandId = brands[0].Id,
            },
            new Category()
            {
				Id = Guid.NewGuid(),
                Name = "Экшн-камеры",
                BrandId = brands[2].Id,
            },
            new Category()
            {
				Id = Guid.NewGuid(),
                Name = "Умные брелоки",
				BrandId = brands[2].Id,
            },
            new Category()
            {
				Id = Guid.NewGuid(),
                Name = "Смарт часы",
				BrandId = brands[2].Id,
            }
        };

		var subCategories = new SubCategory[]
		{
			new SubCategory()
			{
                Name = "Смартфоны",
                CategoryId = categories[0].Id,
            }
		};

		builder.Entity<Admin>().HasData(admins);
		builder.Entity<Country>().HasData(countries);
		builder.Entity<Address>().HasData(addresses);
		builder.Entity<Role>().HasData(roles);
		builder.Entity<User>().HasData(users);
		builder.Entity<Brand>().HasData(brands);
		builder.Entity<Category>().HasData(categories);
		builder.Entity<SubCategory>().HasData(subCategories);
	}
}
