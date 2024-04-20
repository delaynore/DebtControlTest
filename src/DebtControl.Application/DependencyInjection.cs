using DebtControl.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtControl.Application
{
	public static class DependencyInjection
	{

		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			services.AddScoped<IEmployeeService, EmployeeService>();
			services.AddScoped<IShiftService, ShiftService>();

			return services;
		}
	}
}
