using DebtControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DebtControl.Infrastructure.Configurations
{
	internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
	{
		public void Configure(EntityTypeBuilder<Employee> builder)
		{
			builder.HasKey(e => e.Id);
			builder.Property(e => e.FirstName).IsRequired();
			builder.Property(e => e.LastName).IsRequired();

			builder.HasOne(e => e.Position)
				.WithMany(e => e.Employees)
				.HasForeignKey(e => e.Id);

		}
	}
}
