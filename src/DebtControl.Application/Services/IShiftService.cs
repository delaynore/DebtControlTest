using CSharpFunctionalExtensions;
using DebtControl.Dto.Shift;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DebtControl.Application.Services
{
	public interface IShiftService
	{
		Task<Result> StartShiftAsync(StartShiftDto startShiftDto, CancellationToken ct);
		Task<Result> EndShiftAsync(EndShiftDto endShiftDto, CancellationToken ct);
	}
}
