using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtControl.Dto.Shift
{
	public record ShiftDto(
		DateTime? StartTime,
		DateTime? EndTime,
		string HoursWorked,
		bool IsViolation);
}
