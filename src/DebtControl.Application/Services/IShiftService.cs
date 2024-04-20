using CSharpFunctionalExtensions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DebtControl.Application.Services
{
	public interface IShiftService
	{
		Task<Result> StartShiftAsync(Guid employeeId, DateTime startTime, CancellationToken ct);
		Task<Result> EndShiftAsync(Guid employeeId, DateTime endTime, CancellationToken ct);
	}
}
