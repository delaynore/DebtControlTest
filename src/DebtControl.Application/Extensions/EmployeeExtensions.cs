using DebtControl.Domain.Entities;
using DebtControl.Dto.Employee;
using System.Collections.Generic;
using System.Linq;

namespace DebtControl.Application.Extensions
{
	public static class EmployeeExtensions
	{

		public static EmployeeDto ToEmployeeDto(this Employee employee)
		{
			return new EmployeeDto(
				employee.Id,
				employee.FirstName,
				employee.LastName,
				employee.Patronymic,
				employee.Position.ToPositionDto());
		}

		public static ICollection<EmployeeDto> ToEmployeeDtos(this ICollection<Employee> employees)
		{
			return employees.Select(ToEmployeeDto).ToList();
		}
	}
}
