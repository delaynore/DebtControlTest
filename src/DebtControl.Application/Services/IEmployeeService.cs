using CSharpFunctionalExtensions;
using DebtControl.Dto.Employee;
using DebtControl.Dto.Position;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DebtControl.Application.Services
{
	public interface IEmployeeService
	{
		Task<Result<IEnumerable<EmployeeDto>>> GetAllEmployeesAsync(int? positionId, CancellationToken ct);

		Task<Result<EmployeeDto>> GetEmployeeByIdAsync(Guid employeeId, CancellationToken ct);

		Task<Result<EmployeeDto>> CreateEmployeeAsync(CreateEmployeeDto employeeDto, CancellationToken ct);
		Task<Result<EmployeeDto>> UpdateEmployeeAsync(Guid employeeId, UpdateEmployeeDto updateEmployeeDto, CancellationToken ct);

		Task<Result> DeleteEmployeeAsync(Guid employeeId, CancellationToken ct);

		Task<Result<IEnumerable<PositionDto>>> GetAllPositionsAsync(CancellationToken ct);
	}
}
