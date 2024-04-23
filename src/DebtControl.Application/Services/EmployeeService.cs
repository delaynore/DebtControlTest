using CSharpFunctionalExtensions;
using DebtControl.Application.Extensions;
using DebtControl.Domain.Entities;
using DebtControl.Domain.Interfaces;
using DebtControl.Dto.Employee;
using DebtControl.Dto.Position;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DebtControl.Application.Services
{
	public class EmployeeService : IEmployeeService
	{

		private readonly IEmployeeRepository _employeeRepository;
		private readonly IPositionRepository _positionRepository;

		public EmployeeService(IEmployeeRepository employeeRepository, IPositionRepository positionRepository)
		{
			_employeeRepository = employeeRepository;
			_positionRepository = positionRepository;
		}

		public async Task<Result<EmployeeDto>> CreateEmployeeAsync(CreateEmployeeDto employeeDto, CancellationToken ct)
		{
			var position = await _positionRepository.GetPositionByIdAsync(employeeDto.PositionId, ct);

			if (position is null)
			{
				return Result.Failure<EmployeeDto>($"Position with Id('{employeeDto.PositionId}') does not exist");
			}

			var employeeResult = Employee.Create(
				employeeDto.FirstName,
				employeeDto.LastName,
				employeeDto.Patronymic,
				position);

			if (employeeResult.IsFailure)
			{
				return Result.Failure<EmployeeDto>(employeeResult.Error);
			}

			await _employeeRepository.CreateEmployeeAsync(employeeResult.Value, ct);

			return Result.Success(employeeResult.Value.ToEmployeeDto());
		}

		public async Task<Result> DeleteEmployeeAsync(Guid employeeId, CancellationToken ct)
		{
			if (employeeId.Equals(Guid.Empty))
			{
				return Result.Failure("The employee id must be specified");
			}

			var employee = await _employeeRepository.GetEmployeeByIdAsync(employeeId, ct);

			if (employee is null)
			{
				return Result.Failure($"The employee with given Id('{employeeId}') doesn't exist");
			}

			await _employeeRepository.DeleteEmployeeByIdAsync(employeeId, ct);

			return Result.Success();
		}

		public async Task<Result<IEnumerable<EmployeeDto>>> GetAllEmployeesAsync(int? positionId, CancellationToken ct)
		{
			if (positionId.HasValue) {
				var position = await _positionRepository.GetPositionByIdAsync(positionId.Value, ct);

				if (position is null)
				{
					return Result.Failure<IEnumerable<EmployeeDto>>($"Position with specified Id('{positionId}') does not exist");
				}
				
				return Result.Success((await _employeeRepository.GetEmployeesByPositionAsync(positionId.Value, ct)).ToEmployeeDtos());
			}

			return Result.Success((await _employeeRepository.GetAllEmployeesAsync(ct)).ToEmployeeDtos());
		}

		public async Task<Result<IEnumerable<PositionDto>>> GetAllPositionsAsync(CancellationToken ct)
		{
			return Result.Success((await _positionRepository.GetAllPositionsAsync(ct)).ToPositionDtos());
		}

		public Task<Result<EmployeeDto>> GetEmployeeByIdAsync(Guid employeeId, CancellationToken ct)
		{
			throw new NotImplementedException();
		}

		public async Task<Result<EmployeeDto>> UpdateEmployeeAsync(Guid employeeId, UpdateEmployeeDto updateEmployeeDto, CancellationToken ct)
		{
			if (employeeId.Equals(Guid.Empty))
			{
				return Result.Failure<EmployeeDto>("The employee id must be specified");
			}

			if(string.IsNullOrEmpty(updateEmployeeDto?.FirstName))
			{
				return Result.Failure<EmployeeDto>("The employee first name must be specified");
			}

			if (string.IsNullOrEmpty(updateEmployeeDto?.LastName))
			{
				return Result.Failure<EmployeeDto>("The employee first name must be specified");
			}

			if (updateEmployeeDto?.PositionId == 0)
			{
				return Result.Failure<EmployeeDto>("The employee position must be specified");
			}

			var position = await _positionRepository.GetPositionByIdAsync(updateEmployeeDto.PositionId, ct);

			if (position is null)
			{
				return Result.Failure<EmployeeDto>($"Position with specified id('{updateEmployeeDto.PositionId}') does not exist");
			}

			var employee = await _employeeRepository.GetEmployeeByIdAsync(employeeId, ct);

			if (employee is null)
			{
				return Result.Failure<EmployeeDto>($"The employee with given Id('{employeeId}') doesn't exist");
			}

			employee.FirstName = updateEmployeeDto.FirstName;
			employee.LastName = updateEmployeeDto.LastName;
			employee.Patronymic = updateEmployeeDto.Patronymic;
			employee.Position = position;

			await _employeeRepository.UpdateEmployeeAsync(employee, ct);

			return employee.ToEmployeeDto();
		}
	}
}
