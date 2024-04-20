using CSharpFunctionalExtensions;
using DebtControl.Domain.Entities;
using DebtControl.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

		public async Task CreateEmployee(Employee newEmployee, CancellationToken ct)
		{
			await _dbContext.Employees.AddAsync(newEmployee, ct);
			await _dbContext.SaveChangesAsync(ct);
		}

		public async Task DeleteEmployeeById(Guid id, CancellationToken ct)
		{
			var employee = await _dbContext.Employees
				.FirstOrDefaultAsync(x => x.Id.Equals(id), ct);

			_dbContext.Remove(employee);
			await _dbContext.SaveChangesAsync(ct);
		}

		public Task<ICollection<Employee>> GetAllEmployees(CancellationToken ct)
		{
			return Task.FromResult(
				(ICollection<Employee>)_dbContext.Employees
					.AsNoTracking()
					.Include(x => x.Position)
					.ToListAsync(ct));
		}

		public Task<Employee> GetEmployeeById(Guid id, CancellationToken ct)
		{
			return _dbContext.Employees
				.Include(x => x.Position)
				.FirstOrDefaultAsync(x => x.Id.Equals(id), ct);
		}

		public Task<ICollection<Employee>> GetEmployeesByPosition(int positionId, CancellationToken ct)
		{
			return Task.FromResult(
				(ICollection<Employee>)_dbContext.Employees
					.AsNoTracking()
					.Include(x => x.Position)
					.Where(x => x.PositionId == positionId)
					.ToListAsync(ct));
		}

		public async Task UpdateEmployee(Employee updatedEmployee, CancellationToken ct)
		{
			_dbContext.Employees.Update(updatedEmployee);

			await _dbContext.SaveChangesAsync(ct);
		}
	}
}
