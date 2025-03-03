namespace WebAPI_Binding_Routing_Validation.DTOs
{
	public class CompanyForCreationDto
	{
		public ICollection<EmployeeForCreationDto> Employees { get; set; }
	}
}
