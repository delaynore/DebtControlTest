using DebtControl.Domain.Entities;
using DebtControl.Dto.Shift;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtControl.Application.Extensions
{
	public static class ShiftExtensions
	{

		public static ShiftDto ToShiftDto(this Shift shift)
		{
			return new ShiftDto(
				shift.StartTime,
				shift.EndTime,
				shift.HoursWorked.Value.TotalHours.ToString(),
				shift.IsEveningScheduleViolation 
					&& shift.IsMorningSchuduleViolation);
		}

		public static IEnumerable<ShiftDto> ToShiftDtos(this IEnumerable<Shift> shift)
		{
			return shift.Select(ToShiftDto);
		}
	}
}
