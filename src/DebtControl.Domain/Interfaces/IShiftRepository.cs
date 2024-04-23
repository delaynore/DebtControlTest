using DebtControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DebtControl.Domain.Interfaces
{
	public interface IShiftRepository
	{
		Task CreateShiftAsync(Shift shift, CancellationToken ct);
		Task UpdateShiftAsync(Shift shift, CancellationToken ct);

		Task<IEnumerable<Shift>> GetEmployeeShiftsAsync(Guid employeeId, CancellationToken ct);

		Task<Shift> GetLastShiftAsync(Guid employeeId, CancellationToken ct);
	}
}
