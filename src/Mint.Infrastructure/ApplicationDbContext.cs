using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Mint.Domain.Models;

namespace Mint.Infrastructure;

public class ApplicationDbContext : DbContext
{
	public DbSet<User> Users { get; set; } = null!;

	public DbSet<Photo> Photos { get; set; } = null!;

	public DbSet<Role> Roles { get; set; } = null!;

	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
		: base(options) { }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		builder.Entity<User>()
			.HasOne(x => x.Role)
			.WithMany(x => x.Users)
			.HasForeignKey(x => x.RoleId)
			.OnDelete(DeleteBehavior.NoAction);
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
