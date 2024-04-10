using _3S.Task.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3S.Task.InfraStructure.DI
{
	public static class DependecyInjection
	{
		public static IServiceCollection AddInfraStructure(this IServiceCollection services)
		{
			var _dbContext = services.GetRequiredService<ApplicationWriteDbContext>();
		
			try
			{
				//database migrate
				await _dbContext.Database.MigrateAsync();
				await _identitydbContext.Database.MigrateAsync();

				//data seeding
				await DataSeeding.DataSeedAsync(_dbContext, _loggerFactory);
				await IdentityDataSeeding.SeedIdentityDataAsync(_userManager);

			}
			catch (Exception ex)
			{

				var _logger = _loggerFactory.CreateLogger<Program>();
				_logger.LogError(ex.ToString(), "There error Ocuard while update DB");

			}
			return services;
		}
	}
}
