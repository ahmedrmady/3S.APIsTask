using _3S.Task.Persistence.Configurations;
using Domain.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Models;
using Task.Domain.Entities;

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
			modelBuilder.ApplyConfiguration(new CityConfiguration());	
		}

		public DbSet<User> Users { get; set; }
		public DbSet<UsersGovsCount> usersGovsCounts { set; get; }

    }
}
