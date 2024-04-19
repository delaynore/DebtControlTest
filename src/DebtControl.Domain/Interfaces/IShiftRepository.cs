using CSharpFunctionalExtensions;
using DebtControl.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DebtControl.Domain.Interfaces
{
	public interface IShiftRepository
	{
		Task<Result<ICollection<Shift>>> GetEmployeeShifts(Guid employeeId, CancellationToken ct);

	}
}
