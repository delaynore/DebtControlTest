using CSharpFunctionalExtensions;
using DebtControl.Domain.Entities;
using DebtControl.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DebtControl.Infrastructure.Repositories
{
	internal class EmployeeRepository : IEmployeeRepository
	{
		private readonly AppDbContext _dbContext;

		public EmployeeRepository(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task CreateEmployeeAsync(Employee newEmployee, CancellationToken ct)
		{
			await _dbContext.Employees.AddAsync(newEmployee, ct);
			await _dbContext.SaveChangesAsync(ct);
		}

		public async Task DeleteEmployeeByIdAsync(Guid id, CancellationToken ct)
		{
			var employee = await _dbContext.Employees
				.FirstOrDefaultAsync(x => x.Id.Equals(id), ct);

			_dbContext.Remove(employee);
			await _dbContext.SaveChangesAsync(ct);
		}

		public async Task<IEnumerable<Employee>> GetAllEmployeesAsync(CancellationToken ct)
		{
			return await _dbContext.Employees
					.AsNoTracking()
					.Include(x => x.Position)
					.Include(x => x.Shifts.Where(x => x.IsEveningScheduleViolation && x.IsMorningSchuduleViolation))
					.ToListAsync(ct);
		}

		public Task<Employee> GetEmployeeByIdAsync(Guid id, CancellationToken ct)
		{
			return _dbContext.Employees
				.Include(x => x.Position)
				.FirstOrDefaultAsync(x => x.Id.Equals(id), ct);
		}

		public async Task<IEnumerable<Employee>> GetEmployeesByPositionAsync(int positionId, CancellationToken ct)
		{
			return await _dbContext.Employees
					.AsNoTracking()
					.Include(x => x.Position)
					.Where(x => x.PositionId == positionId)
					.ToListAsync();
		}

		public async Task UpdateEmployeeAsync(Employee updatedEmployee, CancellationToken ct)
		{
			_dbContext.Employees.Update(updatedEmployee);

			await _dbContext.SaveChangesAsync(ct);
		}
	}
}
