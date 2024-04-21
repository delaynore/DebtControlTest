using System;

namespace DebtControl.Domain.Entities
{
	public class Shift
	{
		public int Id { get; set; }
		public DateTime? StartTime { get; set; }
		public DateTime? EndTime { get; set; }

		public TimeSpan? HoursWorked { get; set; }

		public bool IsMorningSchuduleViolation { get; set; }

		public bool IsEveningScheduleViolation { get; set; }

		public Guid EmployeeId { get; set; }
		public Employee Employee { get; set; }

		public DateTime CreatedAt { get; set; }
	}
}