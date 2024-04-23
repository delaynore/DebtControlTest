using DebtControl.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DebtControl.Domain.Interfaces
{
	public interface IPositionRepository
	{
		Task<IEnumerable<Position>> GetAllPositionsAsync(CancellationToken ct);
		Task<Position> GetPositionByIdAsync(int id, CancellationToken ct);

	}
}
