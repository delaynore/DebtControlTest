using DebtControl.Domain.Interfaces;
using DebtControl.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DebtControl.Infrastructure
{
	public static class DependenyInjection
	{

		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{

			var connectionString = configuration.GetConnectionString("DbConnection");

			if (string.IsNullOrEmpty(connectionString))
			{
				throw new ApplicationException("Database connection string not found");
			}

			services.AddDbContext<AppDbContext>(options =>
			{
				options.UseSqlite(connectionString);
			});

			services.AddScoped<IEmployeeRepository, EmployeeRepository>();
			services.AddScoped<IShiftRepository, ShiftRepository>();
			services.AddScoped<IPositionRepository, PositionRepository>();

			return services;
		}
	}
}
