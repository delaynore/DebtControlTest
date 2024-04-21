using DebtControl.Api.Models;
using DebtControl.Application.Services;
using DebtControl.Dto.Shift;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace DebtControl.Api.Controllers
{
	public class ShiftsController : ApiBaseController
	{
		private readonly IShiftService _shiftService;

		public ShiftsController(IShiftService shiftService)
		{
			_shiftService = shiftService;
		}


		/// <summary>
		/// Starts the employee shift.
		/// </summary>
		/// <param name="createShiftDto">The data to start shift.</param>
		/// <returns>The result of API.</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
		[HttpPost("start")]
		public async Task<IActionResult> StartShift(StartShiftDto createShiftDto)
		{
			var result = await _shiftService.StartShiftAsync(
				createShiftDto, 
				CancellationToken.None);

			return ApiResult(result);
		}

		/// <summary>
		/// Ends the employee shift.
		/// </summary>
		/// <param name="endShiftDto">The data to end shift.</param>
		/// <returns>The result of API.</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
		[HttpPost("end")]
		public async Task<IActionResult> EndShift(EndShiftDto endShiftDto)
		{
			var result = await _shiftService.EndShiftAsync(
				endShiftDto,
				CancellationToken.None);

			return ApiResult(result);
		}
	}
}
