using DebtControl.Domain.Entities;
using DebtControl.Dto.Position;
using System.Collections.Generic;
using System.Linq;

namespace DebtControl.Application.Extensions
{
	public static class PositionExtensions
	{
		public static PositionDto ToPositionDto(this Position position)
		{
			return new PositionDto(position.Id, position.Name);
		}

		public static ICollection<PositionDto> ToPositionDtos(this ICollection<Position> positions)
		{
			return positions.Select(ToPositionDto).ToList();
		}
	}
}
