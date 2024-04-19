using System.Collections.Generic;

namespace DebtControl.Domain.Entities
{
	public class Position
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public ICollection<Employee> Employees { get; set; }
	}
}