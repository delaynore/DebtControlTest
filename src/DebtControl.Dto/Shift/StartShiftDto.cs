using System;

namespace DebtControl.Dto.Shift
{
	public record StartShiftDto(Guid EmployeeId, DateTime StartTime);
}
