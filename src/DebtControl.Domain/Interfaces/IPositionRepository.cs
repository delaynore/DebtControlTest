using DebtControl.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DebtControl.Domain.Interfaces
{
	public interface IPositionRepository
	{
		Task<IEnumerable<Position>> GetAllPositions(CancellationToken ct);
		Task<Position> GetPositionById(int id, CancellationToken ct);

	}
}
