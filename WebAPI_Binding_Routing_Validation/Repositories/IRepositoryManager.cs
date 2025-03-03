namespace WebAPI_Binding_Routing_Validation.Repositories
{
	public interface IRepositoryManager
	{
		ICompanyRepository Company { get; }
		IEmployeeRepository Employee { get; }
		void Save();
	}
}
