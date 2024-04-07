using Domain.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Models;

namespace _3S.Task.Persistence.Contexts
{
    public class ApplicationReadDbContext : DbContext
    {
        public ApplicationReadDbContext(DbContextOptions<ApplicationReadDbContext> options) : base(options)
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
