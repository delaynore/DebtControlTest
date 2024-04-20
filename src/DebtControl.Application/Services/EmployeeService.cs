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

		public async Task<Result<EmployeeDto>> CreateEmployee(CreateEmployeeDto employeeDto, CancellationToken ct)
		{
			var position = await _positionRepository.GetPositionById(employeeDto.PositionId, ct);

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

			await _employeeRepository.CreateEmployee(employeeResult.Value, ct);

			return Result.Success(employeeResult.Value.ToEmployeeDto());
		}

		public async Task<Result> DeleteEmployee(Guid employeeId, CancellationToken ct)
		{
			if (employeeId.Equals(Guid.Empty))
			{
				return Result.Failure("The employee id must be specified");
			}

			var employee = await _employeeRepository.GetEmployeeById(employeeId, ct);

			if (employee is null)
			{
				return Result.Failure($"The employee with given Id('{employeeId}') doesn't exist");
			}

			await _employeeRepository.DeleteEmployeeById(employeeId, ct);

			return Result.Success();
		}

		public async Task<Result<ICollection<EmployeeDto>>> GetAllEmployees(int? positionId, CancellationToken ct)
		{
			if (positionId.HasValue) {
				var position = await _positionRepository.GetPositionById(positionId.Value, ct);

				if (position is null)
				{
					return Result.Failure<ICollection<EmployeeDto>>("Position with specified Id('{positionId}') does not exist");
				}
				
				return Result.Success((await _employeeRepository.GetEmployeesByPosition(positionId.Value, ct)).ToEmployeeDtos());
			}
			//maybe return all employee warnings
			return Result.Success((await _employeeRepository.GetAllEmployees(ct)).ToEmployeeDtos());
		}

		public async Task<Result<ICollection<PositionDto>>> GetAllPositions(CancellationToken ct)
		{
			return Result.Success((await _positionRepository.GetAllPositions(ct)).ToPositionDtos());
		}

		public Task<Result<EmployeeDto>> GetEmployeeById(Guid employeeId, CancellationToken ct)
		{
			throw new NotImplementedException();
		}

		public async Task<Result<EmployeeDto>> UpdateEmployee(Guid employeeId, UpdateEmployeeDto updateEmployeeDto, CancellationToken ct)
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

			var position = await _positionRepository.GetPositionById(updateEmployeeDto.PositionId, ct);

			if (position is null)
			{
				return Result.Failure<EmployeeDto>($"Position with specified id('{updateEmployeeDto.PositionId}') does not exist");
			}

			var employee = await _employeeRepository.GetEmployeeById(employeeId, ct);

			if (employee is null)
			{
				return Result.Failure<EmployeeDto>($"The employee with given Id('{employeeId}') doesn't exist");
			}

			employee.FirstName = updateEmployeeDto.FirstName;
			employee.LastName = updateEmployeeDto.LastName;
			employee.Patronymic = updateEmployeeDto.Patronymic;
			employee.Position = position;

			await _employeeRepository.UpdateEmployee(employee, ct);

			return employee.ToEmployeeDto();
		}
	}
}
