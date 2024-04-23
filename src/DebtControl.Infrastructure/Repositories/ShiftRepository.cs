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
	internal class ShiftRepository : IShiftRepository
	{
		private readonly AppDbContext _dbContext;

		public ShiftRepository(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task CreateShiftAsync(Shift shift, CancellationToken ct)
		{
			await _dbContext.Shifts.AddAsync(shift, ct);
			await _dbContext.SaveChangesAsync(ct);
		}

		public async Task<IEnumerable<Shift>> GetEmployeeShiftsAsync(Guid employeeId, CancellationToken ct)
		{
			return await _dbContext.Shifts
					.AsNoTracking()
					.ToListAsync(ct);
		}

		public Task<Shift> GetLastShiftAsync(Guid employeeId, CancellationToken ct)
		{
			return _dbContext.Shifts
				.Where(x => x.EmployeeId.Equals(employeeId))
				.OrderByDescending(x => x.CreatedAt)
				.FirstOrDefaultAsync(ct);
		}

		public async Task UpdateShiftAsync(Shift shift, CancellationToken ct)
		{
			_dbContext.Shifts.Update(shift);
			await _dbContext.SaveChangesAsync(ct);
		}
	}
}
