using CSharpFunctionalExtensions;
using DebtControl.Domain.Entities;
using DebtControl.Domain.Interfaces;
using DebtControl.Dto.Shift;
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

		public async Task<Result> StartShiftAsync(StartShiftDto startShiftDto, CancellationToken ct)
		{
			var employee = await _employeeRepository.GetEmployeeById(startShiftDto.EmployeeId, ct);

			if (employee is null)
			{
				return Result.Failure($"Employee with Id('{startShiftDto.EmployeeId}')  doesn't exist");
			}

			var lastShift = await _shiftRepository.GetLastShiftAsync(startShiftDto.EmployeeId, ct);

			if (lastShift is not null && !lastShift.EndTime.HasValue)
			{
				return Result.Failure("The employee did not close the previous shift");
			}

			var newShift = new Shift()
			{
				StartTime = startShiftDto.StartTime,
				EmployeeId = startShiftDto.EmployeeId,
				CreatedAt = DateTime.Now
			};


			await _shiftRepository.CreateShift(newShift, ct);

			return Result.Success();
		}

		public async Task<Result> EndShiftAsync(EndShiftDto endShiftDto, CancellationToken ct)
		{
			var employee = await _employeeRepository.GetEmployeeById(endShiftDto.EmployeeId, ct);

			if (employee is null)
			{
				return Result.Failure($"Employee with Id('{endShiftDto.EmployeeId}')  doesn't exist");
			}

			var lastShift = await _shiftRepository.GetLastShiftAsync(endShiftDto.EmployeeId, ct);

			if (lastShift is null || !lastShift.StartTime.HasValue)
			{
				return Result.Failure("The employee did not open the current shift");
			}

			lastShift.EndTime = endShiftDto.EndTime;
			lastShift.HoursWorked = lastShift.StartTime - endShiftDto.EndTime;

			await _shiftRepository.UpdateShift(lastShift, ct);

			return Result.Success();
		}

	}
}
