namespace WebAPI_Binding_Routing_Validation.DTOs
{
	public class CompanyForUpdateDto : CompanyForManipulationDto
	{
		public IEnumerable<EmployeeForCreationDto>? Employees { get; set; }
	} 
}
