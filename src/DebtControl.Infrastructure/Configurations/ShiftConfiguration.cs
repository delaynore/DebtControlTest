using DebtControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DebtControl.Infrastructure.Configurations
{
	internal class ShiftConfiguration : IEntityTypeConfiguration<Shift>
	{
		public void Configure(EntityTypeBuilder<Shift> builder)
		{
			builder.HasKey(e => e.Id);
			builder.Property(e => e.StartTime);
			builder.Property(e => e.EndTime);
			builder.Property(e => e.HoursWorked);

			builder.HasOne(e => e.Employee).WithMany(e => e.Shifts).HasForeignKey(e => e.Id);
		}
	}
}
