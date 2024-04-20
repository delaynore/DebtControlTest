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
		Task<Result<ICollection<EmployeeDto>>> GetAllEmployees(int? positionId, CancellationToken ct);

		Task<Result<EmployeeDto>> GetEmployeeById(Guid employeeId, CancellationToken ct);

		Task<Result<EmployeeDto>> CreateEmployee(CreateEmployeeDto employeeDto, CancellationToken ct);
		Task<Result<EmployeeDto>> UpdateEmployee(Guid employeeId, UpdateEmployeeDto updateEmployeeDto, CancellationToken ct);

		Task<Result> DeleteEmployee(Guid employeeId, CancellationToken ct);

		Task<Result<ICollection<PositionDto>>> GetAllPositions(CancellationToken ct);
	}
}
