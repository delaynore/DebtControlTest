using DebtControl.Application.Services;
using DebtControl.Dto.Employee;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DebtControl.Api.Controllers
{
	public class EmployeesController : ApiBaseController
	{

		private readonly IEmployeeService _employeeService;

		public EmployeesController(IEmployeeService employeeService)
		{
			_employeeService = employeeService;
		}

		[HttpPost]
		public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeDto createEmployeeDto)
		{
			var result = await _employeeService.CreateEmployee(createEmployeeDto, CancellationToken.None);

			return ApiResult(result);
		}

		[HttpPut("{employeeId?}")]
		public async Task<IActionResult> UpdateEmployee([FromRoute] Guid employeeId, [FromBody] UpdateEmployeeDto updateEmployeeDto)
		{
			var result = await _employeeService.UpdateEmployee(employeeId, updateEmployeeDto, CancellationToken.None);

			return ApiResult(result);
		}

		[HttpGet("{positionId?}")]
		public async Task<IActionResult> GetEmployees([FromRoute] int? positionId)
		{
			var result = await _employeeService.GetAllEmployees(positionId, CancellationToken.None);

			return ApiResult(result);
		}

		[HttpDelete("{employeeId}")]
		public async Task<IActionResult> DeleteEmployee([FromRoute] Guid employeeId)
		{
			var result = await _employeeService.DeleteEmployee(employeeId, CancellationToken.None);

			return ApiResult(result);
		}

		[HttpGet("positions")]
		public async Task<IActionResult> GetPositions()
		{
			var result = await _employeeService.GetAllPositions(CancellationToken.None);
			return ApiResult(result);
		}
	}
}
