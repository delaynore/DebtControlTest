using DebtControl.Dto.Position;
using System;

namespace DebtControl.Dto.Employee
{
	public record EmployeeDto(
		Guid Id,
		string FirstName, 
		string LastName, 
		string Patronymic, 
		PositionDto Position);
}
