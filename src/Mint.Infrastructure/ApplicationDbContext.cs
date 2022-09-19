using Microsoft.EntityFrameworkCore;
using Mint.Domain.Models;

namespace Mint.Infrastructure;

public class ApplicationDbContext : DbContext
{
	public DbSet<User> Users { get; set; } = null!;

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
}
