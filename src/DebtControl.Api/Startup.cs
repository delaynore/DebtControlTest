using DebtControl.Api.Middleware;
using DebtControl.Application;
using DebtControl.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.IO;
using System.Reflection;
using System;

namespace DebtControl.Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{

			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				var basePath = AppContext.BaseDirectory;
				var xmlPath = Path
					.Combine(basePath, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml");
				c.IncludeXmlComments(xmlPath);

				c.SwaggerDoc("v1", new OpenApiInfo { Title = "DebtControl.Api", Version = "v1" });
			});

			services.AddApplication();
			services.AddInfrastructure(Configuration);

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DebtControl.Api v1"));
			}

			app.UseHttpsRedirection();

			app.UseMiddleware<ExceptionHandlerMiddleware>();

			app.UseRouting();


			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
