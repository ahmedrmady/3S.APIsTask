using Domain.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Models;

namespace _3S.Task.Persistence
{
	public class ApplicationWriteDbContext:DbContext
	{
        public ApplicationWriteDbContext(DbContextOptions<ApplicationWriteDbContext> options):base(options)
        {
                
        }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new UserConfigurations());	
			modelBuilder.ApplyConfiguration(new AddressConfigurations());	
		}

		public DbSet<User> Users { get; set; }

    }
}
