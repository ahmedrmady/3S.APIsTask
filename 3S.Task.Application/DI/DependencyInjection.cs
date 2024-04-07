using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Task.Application.Mapper;

namespace Task.Application.DI
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			#region Fluent Validation

			//services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
			services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

			#endregion

			#region Inject Service

			services.AddAutoMapper(typeof(MappingProfile));

			#endregion

			#region Mediator

			// services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
			services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

			#endregion

			return services;
		}
	}
}
