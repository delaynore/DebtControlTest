using CSharpFunctionalExtensions;
using DebtControl.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace DebtControl.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	[Consumes("application/json")]
	[Produces("application/json")]
	public class ApiBaseController : ControllerBase
	{
		protected IActionResult ApiResult<T>(Result<T> result)
		{
			return result.IsSuccess ? Ok(result.Value) : BadRequest(new BadRequestResponse(result.Error));
		}
		protected IActionResult ApiResult(Result result)
		{
			return result.IsSuccess ? Ok() : BadRequest(new BadRequestResponse(result.Error));
		}
	}
}
