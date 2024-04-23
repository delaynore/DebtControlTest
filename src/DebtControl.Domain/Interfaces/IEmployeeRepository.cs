using DebtControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DebtControl.Domain.Interfaces
{
	public interface IEmployeeRepository
	{
		Task<IEnumerable<Employee>> GetAllEmployeesAsync(CancellationToken ct);
		Task<IEnumerable<Employee>> GetEmployeesByPositionAsync(int position, CancellationToken ct);
		Task<Employee> GetEmployeeByIdAsync(Guid id, CancellationToken ct);
		Task CreateEmployeeAsync(Employee newEmployee, CancellationToken ct);
		Task UpdateEmployeeAsync(Employee updatedEmployee, CancellationToken ct);
		Task DeleteEmployeeByIdAsync(Guid id, CancellationToken ct);
	}
}
