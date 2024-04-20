using DebtControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DebtControl.Domain.Interfaces
{
	public interface IEmployeeRepository
	{
		Task<ICollection<Employee>> GetAllEmployees(CancellationToken ct);
		Task<ICollection<Employee>> GetEmployeesByPosition(int position, CancellationToken ct);
		Task<Employee> GetEmployeeById(Guid id, CancellationToken ct);
		Task<Employee> CreateEmployee(Employee newEmployee, CancellationToken ct);
		Task<Employee> UpdateEmployee(Employee updatedEmployee, CancellationToken ct);
		Task DeleteEmployeeById(Guid id, CancellationToken ct);
	}
}
