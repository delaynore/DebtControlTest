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
	internal class PositionRepository : IPositionRepository
	{
		private readonly AppDbContext _dbContext;

		public PositionRepository(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<ICollection<Position>> GetAllPositions(CancellationToken ct)
		{
			return await _dbContext.Positions.AsNoTracking().ToListAsync(ct);
		}

		public Task<Position> GetPositionById(int id, CancellationToken ct)
		{
			return _dbContext.Positions.SingleOrDefaultAsync(x=>x.Id == id, ct);
		}
	}
}
