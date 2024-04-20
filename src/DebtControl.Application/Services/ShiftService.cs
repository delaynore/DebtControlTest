using CSharpFunctionalExtensions;
using DebtControl.Domain.Entities;
using DebtControl.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DebtControl.Application.Services
{

	public class ShiftService : IShiftService
	{
		private readonly IShiftRepository _shiftRepository;
		private readonly IEmployeeRepository _employeeRepository;

        public ShiftService(IEmployeeRepository employeeRepository, IShiftRepository shiftRepository)
        {
			_employeeRepository = employeeRepository;
			_shiftRepository = shiftRepository;
		}

        public async Task<Result> StartShiftAsync(Guid employeeId, DateTime startTime, CancellationToken ct)
		{
			var employee = await _employeeRepository.GetEmployeeById(employeeId, ct);

			if (employee is null)
			{
				return Result.Failure($"Employee with Id('{employeeId}')  doesn't exsit");
			}

			var lastShift = await _shiftRepository.GetLastShiftAsync(employeeId, ct);
			
			if (lastShift is not null && !lastShift.EndTime.HasValue)
			{
				return Result.Failure("The employee did not close the previous shift");
			}

			var newShift = new Shift()
			{
				StartTime = startTime,
				EmployeeId = employeeId
			};

			await _shiftRepository.CreateShift(newShift, ct);

			return Result.Success();
		}

		public async Task<Result> EndShiftAsync(Guid employeeId, DateTime endTime, CancellationToken ct)
		{
			var employee = await _employeeRepository.GetEmployeeById(employeeId, ct);

			if (employee is null)
			{
				return Result.Failure($"Employee with Id('{employeeId}')  doesn't exsit");
			}

			var lastShift = await _shiftRepository.GetLastShiftAsync(employeeId, ct);

			if (lastShift is not null && !lastShift.StartTime.HasValue)
			{
				return Result.Failure("The employee did not open the current shift");
			}

			lastShift.EndTime = endTime;
			lastShift.HoursWorked = lastShift.StartTime - endTime;

			await _shiftRepository.UpdateShift(lastShift, ct);

			return Result.Success();
		}

	}
}
