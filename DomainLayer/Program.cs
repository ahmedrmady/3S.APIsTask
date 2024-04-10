using Task.Application.DI;
using _3S.Task.Persistence.DI;
using _3S.Task.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DomainLayer
{
	public class Program
	{
		public static async System.Threading.Tasks.Task Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			
			var configuration = builder.Configuration;
			builder.Services.AddPresistence(configuration);
			builder.Services.AddApplication();


			var app = builder.Build();

			#region Update-DataBase and data seding 

			using var Scope = app.Services.CreateScope();

			var Services = Scope.ServiceProvider;
			var _loggerFactory = Services.GetRequiredService<ILoggerFactory>();

			var _dbContext = Services.GetRequiredService<ApplicationWriteDbContext>();

			try
			{
				//database migrate
				await _dbContext.Database.MigrateAsync();
			}
			catch (Exception ex)
			{

				var _logger = _loggerFactory.CreateLogger<Program>();
				_logger.LogError(ex.ToString(), "There error Ocuard while update DB");

			}
			#endregion
			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
