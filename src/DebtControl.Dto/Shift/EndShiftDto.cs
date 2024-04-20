using System;

namespace DebtControl.Dto.Shift
{
	public record EndShiftDto(Guid EmployeeId, DateTime EndTime);
}
