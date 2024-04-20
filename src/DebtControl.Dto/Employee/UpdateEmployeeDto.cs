using System.ComponentModel.DataAnnotations;

namespace DebtControl.Dto.Employee
{
	public record UpdateEmployeeDto(
		[Required] string FirstName, 
		[Required] string LastName, 
		string Patronymic, 
		[Required] int PositionId);
}
