using CSharpFunctionalExtensions;
using DebtControl.Domain.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DebtControl.Domain.Interfaces
{
	public interface IPositionRepository
	{
		Task<Result<ICollection<Position>>> GetAllPositions(CancellationToken ct);
		Task<Result<Position>> GetPositionById(int id, CancellationToken ct);

	}
}
