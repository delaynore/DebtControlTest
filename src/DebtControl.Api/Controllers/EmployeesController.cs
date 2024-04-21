using DebtControl.Api.Models;
using DebtControl.Application.Services;
using DebtControl.Dto.Employee;
using DebtControl.Dto.Position;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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


		/// <summary>
		/// Creates an employee.
		/// </summary>
		/// <param name="createEmployeeDto">The employee data.</param>
		/// <returns>The created employee.</returns>
		[ProducesResponseType(typeof(EmployeeDto), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
		[HttpPost]
		public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeDto createEmployeeDto)
		{
			var result = await _employeeService.CreateEmployee(createEmployeeDto, CancellationToken.None);

			return ApiResult(result);
		}

		/// <summary>
		/// Updates an employee.
		/// </summary>
		/// <param name="employeeId">The Id of the employee to update.</param>
		/// <param name="updateEmployeeDto">The updated employee data.</param>
		/// <returns>The updated employee.</returns>
		[ProducesResponseType(typeof(EmployeeDto), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
		[HttpPut("{employeeId?}")]
		public async Task<IActionResult> UpdateEmployee([FromRoute] Guid employeeId, [FromBody] UpdateEmployeeDto updateEmployeeDto)
		{
			var result = await _employeeService.UpdateEmployee(employeeId, updateEmployeeDto, CancellationToken.None);

			return ApiResult(result);
		}

		/// <summary>
		/// Get all employees.
		/// </summary>
		/// <param name="positionId">Optional parameter. If specified returns employees with this position.</param>
		/// <returns>Employees.</returns>
		[ProducesResponseType(typeof(ICollection<EmployeeDto>), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
		[HttpGet()]
		public async Task<IActionResult> GetEmployees(int? positionId = null)
		{
			var result = await _employeeService.GetAllEmployees(positionId, CancellationToken.None);

			return ApiResult(result);
		}

		/// <summary>
		/// Deletes employee.
		/// </summary>
		/// <param name="employeeId">The Id of employee to delete.</param>
		/// <returns>The result of API.</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
		[HttpDelete("{employeeId}")]
		public async Task<IActionResult> DeleteEmployee([FromRoute] Guid employeeId)
		{
			var result = await _employeeService.DeleteEmployee(employeeId, CancellationToken.None);

			return ApiResult(result);
		}

		/// <summary>
		/// Get all positions.
		/// </summary>
		/// <returns>Positions.</returns>
		[ProducesResponseType(typeof(ICollection<PositionDto>), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(BadRequestResponse), StatusCodes.Status400BadRequest)]
		[HttpGet("positions")]
		public async Task<IActionResult> GetPositions()
		{
			var result = await _employeeService.GetAllPositions(CancellationToken.None);
			return ApiResult(result);
		}
	}
}
