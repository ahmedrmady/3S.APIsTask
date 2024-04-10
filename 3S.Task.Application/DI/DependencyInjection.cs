using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Task.Application.Features;
using Task.Application.Features.User.Validations;
using Task.Application.Mapper;
using MediatR;
using System.Reflection;
using Task.Domain.Shared;
using System.Net.NetworkInformation;

namespace Task.Application.DI
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{

			services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);


			services.AddAutoMapper(typeof(MappingProfile));

			services.AddMediatR(cfg =>
						  cfg.RegisterServicesFromAssembly(typeof(Ping).Assembly));
			services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));


			return services;
		}
	}
}
