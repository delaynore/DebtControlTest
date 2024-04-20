using DebtControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DebtControl.Infrastructure
{
	public class AppDbContext : DbContext
	{

		public DbSet<Employee> Employees => Set<Employee>();

		public DbSet<Position> Positions => Set<Position>();

		public DbSet<Shift> Shifts => Set<Shift>();


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
			base.OnModelCreating(modelBuilder);
		}
	}
}
