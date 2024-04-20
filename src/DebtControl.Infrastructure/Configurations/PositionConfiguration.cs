﻿using DebtControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DebtControl.Infrastructure.Configurations
{
	internal class PositionConfiguration : IEntityTypeConfiguration<Position>
	{
		public void Configure(EntityTypeBuilder<Position> builder)
		{
			builder.HasKey(e => e.Id);

			builder.Property(e => e.Name).IsRequired();

			builder.HasData(
				new Position() { Id = 1, Name = "Менеджер"},
				new Position() { Id = 2, Name = "Инженер"},
				new Position() { Id = 3, Name = "Тестировщик свечей" }
				);
		}
	}
}
