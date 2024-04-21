using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace DebtControl.Api.Middleware
{
	public sealed class ExceptionHandlerMiddleware
	{

		private readonly RequestDelegate _next;
		public ExceptionHandlerMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception ex)
			{
				var response = new
				{
					Code = StatusCodes.Status500InternalServerError,
					ex.Message
				};
				context.Response.StatusCode = response.Code;
				context.Response.ContentType = "application/json";
				await context.Response.WriteAsJsonAsync(response);
			}
		}
	}
}
