using DebtControl.Dto.Position;
using DebtControl.Dto.Shift;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DebtControl.Dto.Employee
{
	public record EmployeeDto(
		Guid Id,
		string FirstName, 
		string LastName, 
		string Patronymic, 
		PositionDto Position,
		IEnumerable<ShiftDto> ViolationShifts);
}
