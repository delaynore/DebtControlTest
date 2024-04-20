using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;

namespace DebtControl.Domain.Entities
{

	public class Employee
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Patronymic { get; set; }

        public int PositionId { get; set; }

        public Position Position { get; set; }

		public ICollection<Shift> Shifts { get; set; } = new List<Shift>();

		private Employee(Guid id, string firstName, string lastName, string patronymic, Position position)
		{
			Id = id;
			FirstName = firstName;
			LastName = lastName;
			Patronymic = patronymic;
			PositionId = position.Id;
			Position = position;
		}

		public static Result<Employee> Create(string firstName, string lastName, string patronymic, Position position) 
		{
			if (string.IsNullOrEmpty(firstName))
			{
				return Result.Failure<Employee>("The employee first name must be specified");
			}

			if (string.IsNullOrEmpty(lastName))
			{
				return Result.Failure<Employee>("The employee last name must be specified");
			}

			if (position is null)
			{
				return Result.Failure<Employee>("The employee position must be specified");
			}

			return new Employee(Guid.NewGuid(), firstName, lastName, patronymic, position);
		}
	}
}
