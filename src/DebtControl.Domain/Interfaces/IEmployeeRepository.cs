using CSharpFunctionalExtensions;
using DebtControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DebtControl.Domain.Interfaces
{
	public interface IEmployeeRepository
	{
		Task<Result<ICollection<Employee>>> GetEmployees(CancellationToken ct);
		Task<Result<Employee>> GetEmployeeById(Guid id, CancellationToken ct);
		Task<Result> CreateEmployee(Employee newEmployee, CancellationToken ct);
		Task<Result> UpdateEmployee(Employee updatedEmployee, CancellationToken ct);
		Task<Result> DeleteEmployeeById(Guid id, CancellationToken ct);
	}
}
