using CSharpFunctionalExtensions;
using System;
using System.Collections;
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

		public static Result<Employee> Create(Guid id, string firstName, string lastName, string patronymic, Position position) 
		{
			// todo validation
			return new Employee(id, firstName, lastName, patronymic, position);
		}

	}

}
