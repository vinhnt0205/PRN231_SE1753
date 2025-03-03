using Microsoft.EntityFrameworkCore;

namespace WebAPI_Binding_Routing_Validation.Models
{
	public class RepositoryContext : DbContext
	{
		public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
		{
		}
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Company> Companies { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
			modelBuilder.ApplyConfiguration(new CompanyConfiguration());
		}
	}
}
