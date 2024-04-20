using DebtControl.Application.Services;
using DebtControl.Dto.Shift;
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

		[HttpPost("start")]
		public async Task<IActionResult> StartShift(StartShiftDto createShiftDto)
		{
			var result = await _shiftService.StartShiftAsync(
				createShiftDto, 
				CancellationToken.None);

			return ApiResult(result);
		}

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
