using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebAPI_Binding_Routing_Validation.Models
{
	public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
	{
		public void Configure(EntityTypeBuilder<Employee> builder)
		{
			builder.HasData(
				new Employee
				{
					Id = Guid.Parse("bc08debb-2262-40b6-9a28-d6ca57ca95b6"),
					Name = "Vinh",
					Age = 30,
					Position = "Software Developer",
					CompanyId = Guid.Parse("44b72866-168a-41c0-83d9-1e92f10cdb4c")
				},
				new Employee
				{
					Id = Guid.Parse("9aaa5867-5e62-41fb-93e7-0329c5e20045"),
					Name = "Tien",
					Age = 25,
					Position = "Software Developer",
					CompanyId = Guid.Parse("4477411b-6651-4a20-b3e4-bfd11937c515")
				},
				new Employee
				{
					Id = Guid.Parse("94b7c3db-0782-4b69-b2fd-55f74109984d"),
					Name = "Hai",
					Age = 35,
					Position = "Software Developer",
					CompanyId = Guid.Parse("44b72866-168a-41c0-83d9-1e92f10cdb4c")
				});
		}
	}
}
