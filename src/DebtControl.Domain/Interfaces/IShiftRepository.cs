using DebtControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DebtControl.Domain.Interfaces
{
	public interface IShiftRepository
	{
		Task CreateShift(Shift shift, CancellationToken ct);
		Task UpdateShift(Shift shift, CancellationToken ct);

		Task<IEnumerable<Shift>> GetEmployeeShifts(Guid employeeId, CancellationToken ct);

		Task<Shift> GetLastShiftAsync(Guid employeeId, CancellationToken ct);
	}
}
