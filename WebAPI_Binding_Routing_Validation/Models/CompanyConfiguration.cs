using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebAPI_Binding_Routing_Validation.Models
{
	public class CompanyConfiguration : IEntityTypeConfiguration<Company>
	{
		public void Configure(EntityTypeBuilder<Company> builder)
		{
			builder.HasData(
				new Company
				{
					Id = Guid.Parse("44b72866-168a-41c0-83d9-1e92f10cdb4c"),
					Name = "SMAC",
					Address = "Thanh Xuan",
					Country = "VN"
				},
				new Company
				{
					Id = Guid.Parse("4477411b-6651-4a20-b3e4-bfd11937c515"),
					Name = "FPT",
					Address = "Hoa Lac",
					Country = "VN"
				});
		}
	}
}
