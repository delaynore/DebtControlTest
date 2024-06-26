﻿using System.ComponentModel.DataAnnotations;

namespace DebtControl.Dto.Employee
{
	public record CreateEmployeeDto(
		[Required] string FirstName, 
		[Required] string LastName, 
		string Patronymic, 
		[Required] int PositionId);
}
