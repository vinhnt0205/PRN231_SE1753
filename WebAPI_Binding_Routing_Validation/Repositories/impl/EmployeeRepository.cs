using WebAPI_Binding_Routing_Validation.Models;

namespace WebAPI_Binding_Routing_Validation.Repositories.impl
{
	public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
	{
		public EmployeeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
		{
		}

		public void CreateEmployeeForCompany(Guid companyId, Employee employee)
		{
			employee.CompanyId = companyId;
			Create(employee);
		}

		public void DeleteEmployee(Employee employee)
		{
			Delete(employee);
		}

		public Employee GetEmployee(Guid companyId, Guid id, bool trackChanges)
		{
			return FindByCondition(x => x.Id.Equals(id) && x.CompanyId.Equals(companyId), trackChanges).SingleOrDefault();
		}

		public IEnumerable<Employee> GetEmployees(Guid companyId, bool trackChanges)
		{
			return FindByCondition(x => x.CompanyId.Equals(companyId), trackChanges);
		}
	}
}
