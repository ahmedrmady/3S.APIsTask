using _3S.Task.Persistence.Contexts;
using _3S.Task.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Domain.Interfaces;

namespace _3S.Task.Persistence.DI
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddPresistence(this IServiceCollection services, IConfiguration configuration)
		{
			var connectionstring = configuration.GetConnectionString("ECORead");
			services.AddDbContext<ApplicationReadDbContext>(option => option.UseSqlServer(connectionstring));

			var connectionstringwrite = configuration.GetConnectionString("ECOWrite");
			services.AddDbContext<ApplicationWriteDbContext>(option => option.UseSqlServer(connectionstringwrite));

			services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

			return services;
		}
	}
}
