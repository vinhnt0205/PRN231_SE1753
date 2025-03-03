using AutoMapper;
using WebAPI_Binding_Routing_Validation.DTOs;
using WebAPI_Binding_Routing_Validation.Models;
namespace WebAPI_Binding_Routing_Validation.Mapper
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Company, CompanyDto>()
				.ForMember(c => c.FullAddress,
					opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country)));
			CreateMap<Employee, EmployeeDto>();
			CreateMap<CompanyForCreationDto, Company>();
			CreateMap<EmployeeForCreationDto, Employee>();
			CreateMap<EmployeeForUpdateDto, Employee>().ReverseMap();
			CreateMap<CompanyForUpdateDto, Company>();
		}
	}
}
